using System.Collections.Generic;

namespace Schaad.TeamLunch.WebUi.Models
{
    public class VotingModel
    {
        public IList<RestaurantVote> Votes { get; set; }

        public VotingModel()
        {

        }

        public VotingModel( IList<RestaurantVote> votes)
        {
            Votes = votes;
        }
    }

    public class RestaurantVote
    {
        public string RestaurantName { get; set; }
        public int RestaurantId { get; set; }
        public bool IsVoted { get; set; }
    }
}