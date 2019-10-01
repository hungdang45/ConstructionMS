using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConstructionMS.Startup))]
namespace ConstructionMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
