using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfiniScrollTest.Startup))]
namespace InfiniScrollTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
