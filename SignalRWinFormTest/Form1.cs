using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRWinFormTest
{
    public partial class Form1 : Form
    {
        private HubConnection hubConnection;
        private IHubProxy hubProxy;
        private delegate void AddTxt(ChatMessageDTO msg);

        private Connection echoConnection;
        private delegate void AddText(string msg);

        private static string path = null;

        public Form1()
        {
            InitializeComponent();
        }

        #region 永久连接方式实现
        private async void EchoConnectAsync()
        {
            var querystringData = new Dictionary<string, string>();
            querystringData.Add("userId", "U_" + DateTime.Now.Ticks);

            echoConnection = new Connection(path ?? "http://push.caitujun.com/signalr/echo", querystringData);
            echoConnection.Received += (req) =>
            {
                if (this.RichTextBoxConsole.IsHandleCreated)
                    this.Invoke(new AddText(ShowString), req);
            };

            echoConnection.Error += (e) => { Trace.WriteLine($"EchoConnectAsync Error: {e.Message}"); };

            echoConnection.Start().Wait();
        }

        private void EchoButton_Click(object sender, EventArgs e)
        {
            echoConnection.Send("EchoConnect==>" + this.TextBoxMessage.Text);
        }
        private void ShowString(string msg)
        {
            this.RichTextBoxConsole.AppendText(msg + "\r\n");
        }
        #endregion

        #region 集线器方式实现

        private async void HubConnectAsync()
        {
            var querystringData = new Dictionary<string, string>();
            querystringData.Add("userId", "U_" + DateTime.Now.Ticks);

            hubConnection = new HubConnection(path ?? "http://push.caitujun.com/signalr/hubs", querystringData);//web服务
            //hubConnection = new HubConnection("http://192.168.1.2:4421/signalr/hubs");//客户端服务

            hubProxy = hubConnection.CreateHubProxy("ChatsHub");
            hubProxy.On<ChatMessageDTO>("SendMessage", (message) =>
            {
                if (this.RichTextBoxConsole.IsHandleCreated)
                    this.Invoke(new AddTxt(Show), message);
            });
            hubProxy.On<string, string>("BroadcastSystemMessage", (desc, msg) =>
             {
                 if (this.RichTextBoxConsole.IsHandleCreated)
                     this.Invoke(new AddText(ShowString), desc + "====》" + msg);
             });
            //hubProxy.On<string>("BroadcastMessageByUserId", (msg) =>
            // {
            //     if (this.RichTextBoxConsole.IsHandleCreated)
            //         this.Invoke(new AddText(ShowString), "====》" + msg);
            // });

            hubConnection.Error += (e) => { Trace.WriteLine($"HubConnectAsync Error: {e.Message}"); };

            hubConnection.Start().Wait();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            hubProxy.Invoke("send", "HubConnect==>" + this.TextBoxMessage.Text);
        }

        private void Show(ChatMessageDTO msg)
        {
            this.RichTextBoxConsole.AppendText(msg.Content + "\r\n");
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

        private void ServicePathSetting_Click(object sender, EventArgs e)
        {
            path = this.service_path.Text.Trim();
            if (!string.IsNullOrEmpty(path))
            {
                HubConnectAsync();
                //EchoConnectAsync();
                this.closeBtn.Enabled = true;
                this.ServicePathSetting.Enabled = false;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            hubConnection.Closed += () => { Trace.WriteLine("关闭连接"); };

            this.closeBtn.Enabled = false;
            this.ServicePathSetting.Enabled = true;
        }
    }
}
