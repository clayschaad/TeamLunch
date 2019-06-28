using System.ComponentModel.DataAnnotations.Schema;

namespace Schaad.TeamLunch.WebUi.Models
{
    [Table("AllowedUser", Schema = "agile")]
    public class AllowedUserModel
    {
        public AllowedUserModel()
        {
        }

        public AllowedUserModel(string email)
        {
            Email = email;
        }

        public int Id { get; set; }
        public string Email { get; set; }
    }
}