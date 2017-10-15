using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoExternalAuth.Startup))]
namespace DemoExternalAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
