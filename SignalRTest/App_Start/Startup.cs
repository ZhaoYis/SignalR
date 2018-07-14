using Microsoft.Owin;
using Owin;
using SignalRTest;

[assembly: OwinStartup(typeof(Startup), "Configuration")]
namespace SignalRTest
{
    public partial class Startup
    {
        #region MyRegion
        public void Configuration(IAppBuilder app)
        {
            //Microsoft.AspNet.SignalR.StockTicker.Startup.ConfigureSignalR(app);

            app.MapSignalR();
            //ConfigureAuth(app);
        }
        #endregion
    }
}