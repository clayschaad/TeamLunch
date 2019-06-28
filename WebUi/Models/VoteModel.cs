using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schaad.TeamLunch.WebUi.Models
{
    [Table("Vote", Schema = "agile")]
    public class VoteModel
    {
        public VoteModel()
        {
            
        }

        public VoteModel(int sprint, DateTime date, string voter, RestaurantModel restaurant)
        {
            Sprint = sprint;
            Date = date;
            Voter = voter;
            Restaurant = restaurant;
        }

        public int Id { get; set; }

        public int Sprint { get; set; }

        public DateTime Date { get; set; }

        public string Voter { get; set; }

        public RestaurantModel Restaurant { get; set; }
    }
}