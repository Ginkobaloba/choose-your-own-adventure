using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetAluminium.Startup))]
namespace AspNetAluminium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
