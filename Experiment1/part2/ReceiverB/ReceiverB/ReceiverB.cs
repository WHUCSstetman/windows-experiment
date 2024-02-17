using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;
using CopyDataStruct;

namespace ReceiverB
{
    public partial class ReceiverB : Form
    {
        public ReceiverB()
        {
            InitializeComponent();
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x004A) 
            {
    
                listBox1.Items.Add("和A成功建立连接");
                MSG msg = Marshal.PtrToStructure<MSG>(m.LParam);   
                string time = DateTime.Now.ToString("HH:mm:ss");

                listBox1.Items.Add($"{time}: {msg.lpData}");
            }
            base.WndProc(ref m);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
