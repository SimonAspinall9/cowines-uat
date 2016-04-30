using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website.CoWines.Startup))]
namespace Website.CoWines
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
