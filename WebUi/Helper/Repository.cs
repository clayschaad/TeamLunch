using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Schaad.TeamLunch.WebUi.Models;

namespace Schaad.TeamLunch.WebUi.Helper
{
    public static class Repository
    {
        public static IList<RestaurantModel> GetRestaurants()
        {
            using (var ctx = new AgileContext())
            {
                return ctx.Restaurants.ToList();
            }
        }

        public static IList<IGrouping<RestaurantModel, VoteModel>> GetRestaurants(int sprint)
        {
            using (var ctx = new AgileContext())
            {
                var sprintVotesByRestaurant = ctx.Votes.Where(v => v.Sprint == sprint).GroupBy(v => v.Restaurant);
                return sprintVotesByRestaurant.OrderByDescending(v => v.Count()).ToList();
            }
        }

        public static ILookup<string, VoteModel> GetVotes(int sprint)
        {
            using (var ctx = new AgileContext())
            {
                return ctx.Votes
                    .Where(v => v.Sprint == sprint)
                    .Include(v => v.Restaurant)
                    .ToLookup(v => v.Voter);
            }
        }

        public static void SaveVotes(string voter, int sprint, VotingModel voting)
        {
            using (var ctx = new AgileContext())
            {
                var oldVotes = ctx.Votes.Where(v => v.Sprint == sprint && v.Voter == voter);
                ctx.Votes.RemoveRange(oldVotes);

                foreach(var v in voting.Votes.Where(vo => vo.IsVoted))
                {
                    ctx.Votes.Add(new VoteModel(sprint, DateTime.Now, voter, ctx.Restaurants.Single(r => r.Id == v.RestaurantId)));
                }
                ctx.SaveChanges();
            }
        }

        public static bool IsUserAllowed(string email)
        {
            using (var ctx = new AgileContext())
            {
                var x = ctx.AllowedUsers.ToList();

                return ctx.AllowedUsers.Any(a => a.Email == email.ToLower());
            }
        }
    }
}