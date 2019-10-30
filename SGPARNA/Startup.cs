using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SGPARNA.Startup))]
namespace SGPARNA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
