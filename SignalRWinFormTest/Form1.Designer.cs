namespace SignalRWinFormTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxMessage = new System.Windows.Forms.TextBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.RichTextBoxConsole = new System.Windows.Forms.RichTextBox();
            this.EchoButton = new System.Windows.Forms.Button();
            this.service_path = new System.Windows.Forms.TextBox();
            this.ServicePathSetting = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxMessage
            // 
            this.TextBoxMessage.Location = new System.Drawing.Point(13, 49);
            this.TextBoxMessage.Multiline = true;
            this.TextBoxMessage.Name = "TextBoxMessage";
            this.TextBoxMessage.Size = new System.Drawing.Size(350, 41);
            this.TextBoxMessage.TabIndex = 0;
            // 
            // ButtonSend
            // 
            this.ButtonSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSend.Location = new System.Drawing.Point(401, 49);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(129, 41);
            this.ButtonSend.TabIndex = 1;
            this.ButtonSend.Text = "集线器方式发送消息";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // RichTextBoxConsole
            // 
            this.RichTextBoxConsole.Location = new System.Drawing.Point(12, 96);
            this.RichTextBoxConsole.Name = "RichTextBoxConsole";
            this.RichTextBoxConsole.Size = new System.Drawing.Size(776, 342);
            this.RichTextBoxConsole.TabIndex = 2;
            this.RichTextBoxConsole.Text = "";
            // 
            // EchoButton
            // 
            this.EchoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EchoButton.Enabled = false;
            this.EchoButton.Location = new System.Drawing.Point(549, 49);
            this.EchoButton.Name = "EchoButton";
            this.EchoButton.Size = new System.Drawing.Size(129, 41);
            this.EchoButton.TabIndex = 1;
            this.EchoButton.Text = "永久连接方式发送消息";
            this.EchoButton.UseVisualStyleBackColor = true;
            this.EchoButton.Click += new System.EventHandler(this.EchoButton_Click);
            // 
            // service_path
            // 
            this.service_path.Location = new System.Drawing.Point(13, 13);
            this.service_path.Name = "service_path";
            this.service_path.Size = new System.Drawing.Size(349, 21);
            this.service_path.TabIndex = 3;
            this.service_path.Text = "http://push.caitujun.com/signalr/hubs";
            // 
            // ServicePathSetting
            // 
            this.ServicePathSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ServicePathSetting.Location = new System.Drawing.Point(400, 13);
            this.ServicePathSetting.Name = "ServicePathSetting";
            this.ServicePathSetting.Size = new System.Drawing.Size(129, 23);
            this.ServicePathSetting.TabIndex = 4;
            this.ServicePathSetting.Text = "设置服务器地址";
            this.ServicePathSetting.UseVisualStyleBackColor = true;
            this.ServicePathSetting.Click += new System.EventHandler(this.ServicePathSetting_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Location = new System.Drawing.Point(549, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(129, 23);
            this.closeBtn.TabIndex = 5;
            this.closeBtn.Text = "断开连接";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.ServicePathSetting);
            this.Controls.Add(this.service_path);
            this.Controls.Add(this.RichTextBoxConsole);
            this.Controls.Add(this.EchoButton);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.TextBoxMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxMessage;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.RichTextBox RichTextBoxConsole;
        private System.Windows.Forms.Button EchoButton;
        private System.Windows.Forms.TextBox service_path;
        private System.Windows.Forms.Button ServicePathSetting;
        private System.Windows.Forms.Button closeBtn;
    }
}

