using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestSimulator.Web.Startup))]
namespace TestSimulator.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
