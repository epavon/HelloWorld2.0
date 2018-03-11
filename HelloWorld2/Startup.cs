using Microsoft.Owin;
using Owin;

//[assembly: OwinStartupAttribute(typeof(HelloWorld2.Startup))]
[assembly: OwinStartup("ProductionConfiguration", typeof(HelloWorld2.Startup))]
namespace HelloWorld2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
