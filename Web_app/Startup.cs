using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_app.Startup))]
namespace Web_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
