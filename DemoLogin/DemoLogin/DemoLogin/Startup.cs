using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoLogin.Startup))]
namespace DemoLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
