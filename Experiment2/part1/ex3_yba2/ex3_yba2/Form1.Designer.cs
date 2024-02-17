using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ex3_yba2
{
    public partial class Form1 : Form
    {
        private TextBox textBoxIPAddress;
        private TextBox textBoxResult;
        private Button buttonStartCommunication;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonStartCommunication = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(20, 20);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(489, 28);
            this.textBoxIPAddress.TabIndex = 0;
            this.textBoxIPAddress.Text = "www.whu.edu.cn";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(20, 64);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(900, 250);
            this.textBoxResult.TabIndex = 1;
            // 
            // buttonStartCommunication
            // 
            this.buttonStartCommunication.Location = new System.Drawing.Point(573, 20);
            this.buttonStartCommunication.Name = "buttonStartCommunication";
            this.buttonStartCommunication.Size = new System.Drawing.Size(100, 30);
            this.buttonStartCommunication.TabIndex = 2;
            this.buttonStartCommunication.Text = "异步通信";
            this.buttonStartCommunication.Click += new System.EventHandler(this.buttonStartCommunication_Click);

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(707, 372);
            this.Controls.Add(this.textBoxIPAddress);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonStartCommunication);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "异步通信";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private async void buttonStartCommunication_Click(object sender, EventArgs e)
        {
            string ipAddress = textBoxIPAddress.Text.Trim();
            string strCmd = "ping www.whu.edu.cn ";
            if (!string.IsNullOrEmpty(ipAddress))
            {
                strCmd = "ping " + ipAddress ;
            }
            for(int i = 0;i<10;i++)
            {
                // 异步执行ping命令
                string pingResult = await ExecutePingCommandAsync(strCmd);

                // 更新UI
                textBoxResult.Text = pingResult;

            }
            
        }

        private async Task<string> ExecutePingCommandAsync(string command)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;

                process.Start();
                process.StandardInput.WriteLine(command);
                process.StandardInput.WriteLine("exit");

                string pingResult = await process.StandardOutput.ReadToEndAsync();

                process.WaitForExit();
                return pingResult;
            }
        }
    }
}
