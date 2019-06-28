using System.Collections.Generic;
using System.Linq;

namespace Schaad.TeamLunch.WebUi.Models
{
    public class WheelModel
    {
        public int Id { get; set; }

        public int Sprint { get; set; }

        public IList<RestaurantModel> Restaurants { get; set; }

        public IList<IGrouping<RestaurantModel, VoteModel>> VotesPerRestaurant { get; set; }

        public bool IsWheelTime { get; set; }

        public WheelModel(int sprint, bool isWheelTime, IList<RestaurantModel> restaurants, IList<IGrouping<RestaurantModel, VoteModel>> votesPerRestaurant)
        {
            Sprint = sprint;
            IsWheelTime = isWheelTime;
            Restaurants = restaurants;
            VotesPerRestaurant = votesPerRestaurant;
        }
    }
}