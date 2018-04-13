using Microsoft.Owin;
using Owin;
using WebApplication2.Infrastructure;

[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
namespace WebApplication2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DI_Configurator.Initialise();

            ConfigureAuth(app);
        }
    }
}
