using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Worthy.Startup))]
namespace Worthy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
