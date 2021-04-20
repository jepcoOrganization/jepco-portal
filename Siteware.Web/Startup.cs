using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Siteware.Web.Startup))]
namespace Siteware.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}