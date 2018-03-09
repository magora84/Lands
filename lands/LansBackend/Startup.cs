using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LansBackend.Startup))]
namespace LansBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
