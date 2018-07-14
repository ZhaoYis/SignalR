using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using SignalRService;

[assembly: OwinStartup(typeof(Startup))]
namespace SignalRService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //允许跨域推送
            app.UseCors(CorsOptions.AllowAll);

            HubConfiguration hubConfiguration = new HubConfiguration
            {
                EnableDetailedErrors = true
            };

            #region 以下两种方式任选其一
            //注册永久连接
            app.Map("/signalr/echo", map =>
            {
                map.RunSignalR<EchoConnection>(hubConfiguration);
            });
            //注册集线器
            app.Map("/signalr/hubs", map =>
            {
                map.RunSignalR(hubConfiguration);
            });
            #endregion
        }
    }
}
