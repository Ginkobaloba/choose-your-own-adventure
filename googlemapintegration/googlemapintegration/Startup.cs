using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(googlemapintegration.Startup))]
namespace googlemapintegration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
