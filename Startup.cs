using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(loudclothes.net.Startup))]
namespace loudclothes.net
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
