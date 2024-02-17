using System;
using CreateCOM;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallCOM
{
    public partial class Form1 : Form
    {
        IExpress_realize ie;
        public Form1()
        {
            InitializeComponent();
            Guid guid = new Guid("0520A50E-48DC-41D4-B4BD-5613202C5165");
            Type type = Type.GetTypeFromCLSID(guid);
            object iex = Activator.CreateInstance(type);
            ie = iex as IExpress_realize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(textBox1.Text);
                int b = int.Parse(textBox2.Text);
                IExpress_realize ie = new IExpress_realize();
                label1.Text = "minus: " + ie.minus(a, b); 
                label2.Text = "divide: " + ie.divide(a, b);
            }
            catch(Exception)
            {
                label1.Text = "minus: ";
                label2.Text = "divide: ";
            }
        }
    }
}
