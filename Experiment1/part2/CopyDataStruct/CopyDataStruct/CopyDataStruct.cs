using System.Drawing;
using System.Runtime.InteropServices;
using System;

namespace CopyDataStruct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        //public IntPtr hwnd;    // 窗口句柄
        //public uint message;   // 消息标识符
        //public string value;   // 消息的内容
        //public IntPtr wParam;  // 消息的附加信息（WPARAM）
        //public IntPtr lParam;  // 消息的附加信息（LPARAM）
        //public DateTime time;  // 消息被放入消息队列的时间
        //public POINT pt;       // 鼠标位置
        public IntPtr dwData;
        public int cbData;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;
    }

    //[StructLayout(LayoutKind.Sequential)]
    //public struct POINT
    //{
    //    public int X;
    //    public int Y;
    //}
}