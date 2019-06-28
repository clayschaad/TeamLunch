using System.ComponentModel.DataAnnotations.Schema;

namespace Schaad.TeamLunch.WebUi.Models
{
    [Table("Restaurant", Schema = "agile")]
    public class RestaurantModel
    {
        public RestaurantModel()
        {
        }

        public RestaurantModel(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }
    }
}