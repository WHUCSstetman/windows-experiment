***实验三：动态链接库DLL创建和调用，COM控件创建和调用***

**动态链接库DLL创建和调用**

使用C++创建DLL实现简单的功能，并在C#环境下调用该DLL

（1）准备工作：新建解决方案，在解决方案下新建两个项目.其中第一个项目为CreateDLL，其输出类型为类库；第二个项目为CallDLL，其输出类型为Windows窗体应用(.NET Framework)或WPF应用(.NET Framework)；

（2）实现创建DLL程序A：创建C++自定义函数源文件和头文件，创建def文件，生成DLL动态链接库；

（3）实现WinForm窗体应用程序B：引用CreateDLL，实现WinForm窗体对C++动态链接库DLL中函数的调用。

实验要求：

（1）DLL功能一：计算输入数据的阶乘，需要判断输入的合法性；

（2）DLL功能二：计算2个输入数据a和b的差(a-b)，若a<b则需先交换a,b的值再计算；

（3）按下“调用DLL”按钮后，窗体WinForm程序调用DLL中的自定义函数，接收信息并显示内容。


**COM控件创建和调用**

创建自定义COM对象，并在C#环境下调用该COM对象

实验要求：

（1）定义COM组件接口IExpress，包括抽象方法；

public interface IExpress

{

  string minus(int a, int b);//返回值形如“9 = 23 - 14”
  
  string divide(int a, int b);//若b为零，则返回“除零错误”；若b不为0，则返回整除表达式，形如“4 = 33 / 8”
  
}

（2）定义类实现COM组件接口IExpress；

（3）WinForm窗口程序调用COM组件，显示结果信息。
