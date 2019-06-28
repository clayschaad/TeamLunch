using System.Data.Entity;
using Schaad.TeamLunch.WebUi.Models;

namespace Schaad.TeamLunch.WebUi.Helper
{
    /// <summary>
    /// http://www.entityframeworktutorial.net/code-first/dataannotation-in-code-first.aspx
    /// </summary>
    public class AgileContext : DbContext
    {
        public AgileContext() : base("name=DefaultConnection")
        {
            
        }

        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<VoteModel> Votes { get; set; }
        public DbSet<AllowedUserModel> AllowedUsers { get; set; }
    }
}