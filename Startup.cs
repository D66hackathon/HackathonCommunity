using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hackathon_Community.Startup))]
namespace Hackathon_Community
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
