using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoubleMindWeb.Startup))]
namespace DoubleMindWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
