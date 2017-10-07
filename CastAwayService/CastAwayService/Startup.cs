using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CastAwayService.Startup))]

namespace CastAwayService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}