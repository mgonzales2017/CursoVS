using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoTesting.Startup))]
namespace DemoTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
