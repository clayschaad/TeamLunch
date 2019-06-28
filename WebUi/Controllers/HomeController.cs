using Microsoft.AspNet.Identity;
using Schaad.TeamLunch.WebUi.Helper;
using Schaad.TeamLunch.WebUi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Schaad.TeamLunch.WebUi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var nextSprint = SprintHelper.GetNextSprint();

            ViewBag.Title = $"Teamlunch Sprint {nextSprint}";

            var isWheelTime = SprintHelper.IsWheelTime();
            if (isWheelTime)
            {
                var votesByRestaurant = Repository.GetRestaurants(nextSprint);
                var votedRestaurants = new List<RestaurantModel>();

                foreach (var restaurant in votesByRestaurant)
                {
                    foreach (var v in restaurant)
                    {
                        votedRestaurants.Add(v.Restaurant);
                    }
                }

                votedRestaurants.Shuffle();
                votedRestaurants.Shuffle();
                votedRestaurants.Shuffle();

                var wheelModel = new WheelModel(nextSprint, isWheelTime, votedRestaurants, votesByRestaurant);
                return View(wheelModel);
            }
            else
            {
                var restaurant = Repository.GetRestaurants();
                var votes = Repository.GetVotes(nextSprint);
                var user = User.Identity.GetUserName();

                IList<RestaurantVote> restaurantVotes = restaurant.Select(r => new RestaurantVote
                {
                    RestaurantId = r.Id,
                    RestaurantName = r.Name,
                    IsVoted = votes[user].Any(v => v.Restaurant.Id == r.Id)
                }).ToList();

                var votingModel = new VotingModel(restaurantVotes);
                return View("Vote", votingModel);
            }
        }

        [HttpPost]
        public ActionResult Vote(VotingModel voting)
        {
            var nextSprint = SprintHelper.GetNextSprint();
            var user = User.Identity.GetUserName();
            Repository.SaveVotes(user, nextSprint, voting);

            return RedirectToAction("Index");
        }
    }
}
