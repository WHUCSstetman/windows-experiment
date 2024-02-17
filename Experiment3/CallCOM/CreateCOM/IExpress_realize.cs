using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CreateCOM
{
    [Guid("F6373A4E-C31D-49F8-8885-57AB38B2BE37")]
    [ComVisible(true)]
    public interface IExpress
    {
        [DispId(1)]
        string minus(int a, int b);
        [DispId(2)]
        string divide(int a, int b);//若b为零，则返回“除零错误”；若b不为0，则返回整除表达式，形如“4 = 33 / 8”
    }
    [Guid("0520A50E-48DC-41D4-B4BD-5613202C5165")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Description("IExpress_realize")]
    public class IExpress_realize:IExpress
    {
        public string minus(int a,int b)
        {
            return $"{a - b} = {a} - {b}";
        }
        public string divide(int a,int b)
        {
            if(b==0)
            {
                return "除零错误";
            }
            else
            {
                return $"{a / b} = {a}/{b}";
            }
        }
    }
}
