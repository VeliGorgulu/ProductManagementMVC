using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductManagementMVC.Startup))]
namespace ProductManagementMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
