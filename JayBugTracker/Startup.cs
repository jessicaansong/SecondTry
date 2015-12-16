using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JayBugTracker.Startup))]
namespace JayBugTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
