using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Schaad.TeamLunch.WebUi.Startup))]
namespace Schaad.TeamLunch.WebUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
