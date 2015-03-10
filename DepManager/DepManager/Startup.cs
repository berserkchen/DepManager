using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DepManager.Startup))]
namespace DepManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
