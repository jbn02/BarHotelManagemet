using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarHotelManagemet.Startup))]
namespace BarHotelManagemet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
