using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomCMS.Startup))]
namespace CustomCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
