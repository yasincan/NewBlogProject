using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NewBlogProject.AdminUI.Startup))]

namespace NewBlogProject.AdminUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
