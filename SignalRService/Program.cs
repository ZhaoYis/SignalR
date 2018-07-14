using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SignalRService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SignalR服务程序";

            StartOptions options = new StartOptions
            {
                Urls = { "http://192.168.1.2:4421/" }
            };
            using (WebApp.Start<Startup>(options))//启动服务，访问路径在这里配置。
            {
                Console.WriteLine("SignalR服务启动中...");
                Console.WriteLine("服务启动成功！ " + DateTime.Now);
                foreach (string url in options.Urls)
                {
                    Console.WriteLine("服务地址：" + url);
                }
                Console.WriteLine("=================================\r\n");
                Console.ReadLine();
            }
        }
    }
}
