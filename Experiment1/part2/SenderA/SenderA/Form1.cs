using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CopyDataStruct;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace SenderA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // FindWindow
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // SendMessage
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] sarr = System.Text.Encoding.Default.GetBytes(userInputTextBox.Text);
            int len = sarr.Length;
            MSG msg;
            msg.dwData = (IntPtr)Convert.ToInt16(0);//可以是任意值,本例中不用到
            msg.cbData = len + 1;//指定lpData内存区域的字节数
            msg.lpData = userInputTextBox.Text;//发送给目标窗口所在进程的数据

            IntPtr hwnd = FindWindow(null, "ReceiverB");
            if (hwnd != IntPtr.Zero)
            {

                IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(msg));
                Marshal.StructureToPtr(msg, pnt, false);
                SendMessage(hwnd, 0x004A, 0, pnt);
            }
            else
            {
                MessageBox.Show("未找到目标窗口");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] sarr = System.Text.Encoding.Default.GetBytes(userInputTextBox.Text);
            int len = sarr.Length;
            MSG msg;
            msg.dwData = (IntPtr)Convert.ToInt16(0);//可以是任意值,本例中不用到
            msg.cbData = len + 1;//指定lpData内存区域的字节数
            msg.lpData = userInputTextBox.Text;//发送给目标窗口所在进程的数据

            IntPtr hwnd = FindWindow(null, "MainWindow");
            if (hwnd != IntPtr.Zero)
            {
                //IntPtr lParam = Marshal.AllocHGlobal(Marshal.SizeOf(msg));
                ////Struct->IntPtr
                //Marshal.StructureToPtr(msg, lParam, false);

                IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(msg));  //初始化消息句柄
                Marshal.StructureToPtr(msg, pnt, false);                 //使句柄指向消息结构体
                SendMessage(hwnd, 0x004A, 0, pnt);                       //发送句柄
            }
            else
            {
                MessageBox.Show("未找到目标窗口");
            }
        }

        public string receiver = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            receiver = comboBox1.SelectedItem.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] sarr = System.Text.Encoding.Default.GetBytes(userInputTextBox.Text);
            int len = sarr.Length;
            MSG msg;
            msg.dwData = (IntPtr)Convert.ToInt16(0);//可以是任意值,本例中不用到
            msg.cbData = len + 1;//指定lpData内存区域的字节数
            msg.lpData = userInputTextBox.Text;//发送给目标窗口所在进程的数据
            IntPtr hwnd = FindWindow(null, receiver);     //窗体句柄
            if (hwnd != IntPtr.Zero)
            {


                IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(msg));  //初始化消息句柄
                Marshal.StructureToPtr(msg, pnt, false);                 //使句柄指向消息结构体
                SendMessage(hwnd, 0x004A, 0, pnt);                       //发送句柄
            }
            else
            {
                MessageBox.Show("未找到目标窗口");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
