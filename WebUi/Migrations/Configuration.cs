namespace Schaad.TeamLunch.WebUi.Migrations
{
    using Schaad.TeamLunch.WebUi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Schaad.TeamLunch.WebUi.Helper.AgileContext>
    {
        // Enable-Migrations –EnableAutomaticMigrations -ContextTypeName Schaad.AgileWebUi.Helper.AgileContext
        // Update-Database
        // Update-Database -ConnectionStringName "RemoteConnection"

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Schaad.TeamLunch.WebUi.Helper.AgileContext context)
        {
            //  This method will be called after migrating to the latest version.

            if (context.Restaurants.Any() == false)
            {
                context.Restaurants.Add(new RestaurantModel("Naanu", "#eae56f"));
                context.Restaurants.Add(new RestaurantModel("Antonio", "#89f26e"));
                context.Restaurants.Add(new RestaurantModel("Nooch", "#7de6ef"));
                context.Restaurants.Add(new RestaurantModel("Don Weber", "#e7706f"));
                context.Restaurants.Add(new RestaurantModel("The Butcher", "#eae56f"));
                context.Restaurants.Add(new RestaurantModel("Bibim Shack", "#89f26e"));
                context.Restaurants.Add(new RestaurantModel("Lilly Jo", "#7de6ef"));
                context.Restaurants.Add(new RestaurantModel("Western Burger House", "#e7706f"));
                context.Restaurants.Add(new RestaurantModel("Pho 50", "#eae56f"));
                context.Restaurants.Add(new RestaurantModel("Techno Park", "#89f26e"));
                context.Restaurants.Add(new RestaurantModel("Migros Restaurant", "#7de6ef"));
                context.Restaurants.Add(new RestaurantModel("Swisscom (Lunch5)", "#e7706f"));
                context.Restaurants.Add(new RestaurantModel("Peking Garden", "#eae56f"));
                context.Restaurants.Add(new RestaurantModel("Celia", "#89f26e"));
                context.Restaurants.Add(new RestaurantModel("Geroldchuchi", "#7de6ef"));
                context.SaveChanges();
            }

            if (context.AllowedUsers.Any() == false)
            {
                context.AllowedUsers.Add(new AllowedUserModel("claudio.schaad@digitecgalaxus.ch"));
                context.SaveChanges();
            }
        }
    }
}
