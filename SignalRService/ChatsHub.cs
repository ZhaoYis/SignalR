using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRService
{
    [HubName("ChatsHub")]
    public class ChatsHub : Hub
    {
        #region 测试代码

        /// <summary>
        /// 向所有客户端发送消息
        /// </summary>
        /// <param name="message"></param>
        public async Task Send(string message)
        {
            //当前连接ID
            string connId = Context.ConnectionId;

            try
            {
                // 调用所有客户端的SendMessage方法
                ChatMessageDTO msg = new ChatMessageDTO
                {
                    SendId = connId,
                    SendUserName = "",
                    Content = message,
                    CreateDate = DateTime.Now
                };

                message = connId + "发送内容>>" + message;
                Console.WriteLine(message);

                await Clients.All.SendMessage(msg);
            }
            catch (Exception e)
            {
                throw new HubException("发送消息发生异常.", new { message = e.Message });
            }
            finally
            {
                SignalrServerToClient.BroadcastMessage($"服务端已经接收到[{connId}]发来的消息，消息内容为：{message}");
            }
        }

        #endregion

        private class ChatMessageDTO
        {
            /// <summary>
            /// 发送人ID
            /// </summary>
            public string SendId { get; set; }
            /// <summary>
            /// 发送方姓名
            /// </summary>
            public string SendUserName { get; set; }
            /// <summary>
            /// 内容
            /// </summary>
            public string Content { get; set; }
            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime CreateDate { get; set; }
        }

        #region 默认事件

        /// <summary>
        /// 客户端连接的时候调用
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            //string userId = ClientQueryString["userId"];

            Trace.WriteLine("客户端连接成功，连接ID是: " + Context.ConnectionId);
            return base.OnConnected();
        }

        /// <summary>
        /// 客户端断开连接的时候调用
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            Trace.WriteLine($"客户端[{Context.ConnectionId}]断开连接");
            return base.OnDisconnected(true);
        }

        /// <summary>
        /// 客户端重新连接的时候调用
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            Trace.WriteLine($"客户端[{Context.ConnectionId}]正在重新连接");

            return base.OnReconnected();
        }
        #endregion
    }

    public class SignalrServerToClient
    {
        static readonly IHubContext _myHubContext = GlobalHost.ConnectionManager.GetHubContext<ChatsHub>();
        public static void BroadcastMessage(string message)
        {
            _myHubContext.Clients.All.BroadcastMessage("系统消息", message);
        }
    }
}
