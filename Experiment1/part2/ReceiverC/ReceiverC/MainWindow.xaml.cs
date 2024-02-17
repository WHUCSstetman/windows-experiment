using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReceiverC
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;

            if (hwndSource != null)
            {
                hwndSource.AddHook(WndProc);
            }
        }

        protected IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == 0x004A)
            {
                CopyDataStruct.MSG message = (CopyDataStruct.MSG)Marshal.PtrToStructure(lParam, typeof(CopyDataStruct.MSG));
                messageListBox.Items.Add("Successfully Contact with SenderA");
                string str = message.lpData;
                string time = DateTime.Now.ToString("HH:mm:ss");

                messageListBox.Items.Add($"{time}: {str}");

            }
            return IntPtr.Zero;
        }

        private void messageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
