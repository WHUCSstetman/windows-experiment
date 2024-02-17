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

namespace CallDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("CreateDLL.dll", EntryPoint = "calculateFactorial", CallingConvention = CallingConvention.Cdecl)]
        public static extern int calculateFactorial(int n);
        [DllImport("CreateDLL.dll", EntryPoint = "calculateSub", CallingConvention = CallingConvention.Cdecl)]
        public static extern int calculateSub(int a, int b);

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            int a = int.Parse(textBox2.Text);
            int b = int.Parse(textBox3.Text);
            if(a<b)
            {
                int temp = a;
                a = b;
                b = temp;
            }
            label1.Text = $"n的阶乘为：{calculateFactorial(n)}";
            label2.Text = $"a与b的差为：{calculateSub(a, b)}";
        }
    }
}
