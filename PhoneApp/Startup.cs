using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhoneApp.Startup))]
namespace PhoneApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
