using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarAmbition.Startup))]
namespace CarAmbition
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
