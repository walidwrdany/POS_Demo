using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POS_Demo.Startup))]
namespace POS_Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
