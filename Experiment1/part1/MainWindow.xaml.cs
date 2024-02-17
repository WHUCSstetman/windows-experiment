using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using static WpfApp1.MainWindow;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static class globalVariables
        {
            public static string Path = "D:\\logs.txt";
        }

        public class FireEventArgs : EventArgs      //事件参数类
        {
            public FireEventArgs(string room, int ferocity)
            { this.room = room; this.ferocity = ferocity; }
            public string room; //火情发生地
            public int ferocity; //火情凶猛程度
        }
        public class FireAlarm
        {
            // 定义火警事件
            public delegate void FireEventHandler(object sender, FireEventArgs fe);
            // 触发火警事件的方法
            public event FireEventHandler FireEvent;
            public void ActivateFireAlarm(string room, int ferocity)
            {
                FireEventArgs fireArgs = new FireEventArgs(room, ferocity);
                FireEvent(this, fireArgs);
            }
        }

        class FireHandlerClass      //用于处理事件的类1：此类定义了实际事件处理代码
        {
            private TextBox textBox;
            private FireAlarm fireAlarm;
            public FireHandlerClass(TextBox textBox_,FireAlarm fireAlarm_)
            {
                textBox= textBox_;
                fireAlarm= fireAlarm_;
            }
            //事件处理类的构造函数使用事件源类作为参数
            public void myBind1(FireAlarm _fireAlarm)
            {
                fireAlarm = _fireAlarm;
                fireAlarm.FireEvent += new FireAlarm.FireEventHandler(ExtinguishFire);
            }

            public void myBind2(FireAlarm _fireAlarm)
            {
                fireAlarm = _fireAlarm;
                fireAlarm.FireEvent += new FireAlarm.FireEventHandler(ExtinguishFire2);
            }
            public void myUnbind1(FireAlarm _fireAlarm)
            {
                fireAlarm = _fireAlarm;
                fireAlarm.FireEvent -= new FireAlarm.FireEventHandler(ExtinguishFire);
            }
            public void myUnbind2(FireAlarm _fireAlarm)
            {
                fireAlarm = _fireAlarm;
                fireAlarm.FireEvent -= new FireAlarm.FireEventHandler(ExtinguishFire2);
            }

            void ExtinguishFire(object sender, FireEventArgs fe)        //实际事件处理
            {
                string filePath = globalVariables.Path;

                using (StreamWriter OutStr = new StreamWriter(filePath, true))
                {
                    OutStr.WriteLine(" {0} 对象调用，灭火事件ExtinguishFire 函数.", sender.ToString());
                    textBox.AppendText(sender.ToString() + " 对象调用，灭火事件ExtinguishFire 函数.");
                    if (fe.ferocity < 2)
                    {
                        OutStr.WriteLine(" 火情发生在{0}，主人浇水后火情被扑灭了", fe.room);
                        textBox.AppendText(" 火情发生在 " + fe.room + "，主人浇水后火情被扑灭了");
                    }
                    else
                    {
                        OutStr.WriteLine("{0} 的火情无法控制，主人打119!", fe.room);
                        textBox.AppendText(fe.room + " 的火情无法控制，主人打119!");

                    }
                }
            }

            void ExtinguishFire2(object sender, FireEventArgs fe)
            {
                string filePath = globalVariables.Path;
                using (StreamWriter OutStr = new StreamWriter(filePath, true))
                {
                    OutStr.WriteLine(" {0} 对象调用，灭火事件ExtinguishFire2 函数，I don't care.", sender.ToString());
                    textBox.AppendText(sender.ToString() + " 对象调用，灭火事件ExtinguishFire2 函数，，I don't care.");
                }
            }
        }

        class FireWatcherClass      //用于处理事件的类2：FireWatcherClass
        {
            private TextBox textBox;
            //事件处理类的构造函数使用事件源类作为参数
            public FireWatcherClass(TextBox textBox_,FireAlarm fireAlarm)
            {
                //将事件处理的代理(函数指针) 添加到FireAlarm 类的FireEvent 事件中，当事件发生时，
                //就会执行指定的函数；
                textBox= textBox_;
                fireAlarm.FireEvent += new FireAlarm.FireEventHandler(WatchFire);
            }
            //当起火事件发生时，用于处理火情的事件
            void WatchFire(object sender, FireEventArgs fe)
            {
                string filePath = globalVariables.Path;
                using (StreamWriter OutStr = new StreamWriter(filePath, true))
                {
                    OutStr.WriteLine(" {0} 对象调用，群众发现火情WatchFire 函数.", sender.ToString());
                    textBox.AppendText(sender.ToString() + " 对象调用，群众发现火情WatchFire 函数.");
                    //根据火情状况，输出不同的信息.
                    if (fe.ferocity < 2)
                    {
                        OutStr.WriteLine(" 群众察到火情发生在{0}，主人浇水后火情被扑灭了", fe.room);
                        textBox.AppendText(" 群众察到火情发生在 " + fe.room + "，主人浇水后火情被扑灭了");
                    }
                    else
                    {
                        OutStr.WriteLine(" 群众无法控制{0} 的火情，消防官兵来到!", fe.room);
                        textBox.AppendText(" 群众无法控制 " + fe.room + " 的火情，消防官兵来到!");
                    }
                }
            }
        }


        FireAlarm firealarm = new FireAlarm();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           FireHandlerClass fireHandler=new FireHandlerClass(Show,firealarm);
            fireHandler.myBind1(firealarm);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            FireHandlerClass fireHandler = new FireHandlerClass(Show, firealarm);
            fireHandler.myBind2(firealarm);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            FireHandlerClass fireHandler = new FireHandlerClass(Show, firealarm);
            fireHandler.myUnbind1(firealarm);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            FireHandlerClass fireHandler = new FireHandlerClass(Show, firealarm);
            fireHandler.myUnbind2(firealarm);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Show.Clear();
            DateTime currentTime = DateTime.Now;
            long seed = currentTime.Ticks;
            Random random = new Random((int)seed);
            int type_i = random.Next(0, 3);
            string Location = Location_Name.Text;
            int feocity = int.Parse(Type_Name.Text);
            firealarm.ActivateFireAlarm(Location, feocity);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {

        }
        //方法A 
    }
}
