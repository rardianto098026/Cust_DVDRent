using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cust_DVDRent.Startup))]
namespace Cust_DVDRent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
