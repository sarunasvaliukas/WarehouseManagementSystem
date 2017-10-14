using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WarehouseSystem.UI.Startup))]
namespace WarehouseSystem.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
