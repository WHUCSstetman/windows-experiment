***实验一：Windows事件处理机制，窗体应用程序消息发送与接收处理***

**1、Windows事件处理机制实验**

（1）准备工作：新建解决方案，在解决方案下新建一个项目, 其输出类型为WPF窗体应用(.NET Framework)；
（2）定义事件参数类：例如定义火警事件参数类；
（3）定义事件触发者：例如定义火警发起者；
（4）定义事件响应者：例如定义火警的处理者类及具体的两个处理函数，参数类型与上述委托事件对象类的参数类型和个数保持一致；
（5）动态绑定或解绑事件触发者与事件响应者。绑定：假定定义了全局变量FireAlarm fire，通过函数bind1和bind2来进行动态绑定。解绑：通过函数unbind1和unbind2来动态解绑；
（6）触发：假定触发火警事件，封装在方法btn中。	

  要求：
  
  功能性要求：
  
（1）能够自定义事件参数，该参数能在事件触发者和事件响应者之间传递信息；
（2）能够自定义事件发起者，在其中能够基于委托delegate自定义事件对象类型，以及基于event自定义事件对象；
（3）能够自定义事件响应者（类/函数）；
（4）在界面中通过按钮为事件发起者绑定或解绑事件响应者；
（5）在界面中通过按钮触发事件，所绑定的事件响应者（函数）能识别事件参数中携带的信息，并进行处理。

  业务逻辑要求：
  
（1）按下“触发者”按钮后，触发自定义事件；
（2）事件响应者识别事件参数信息，处理事件并打印到文本框。
	
 
 **2、Windows消息发送与接收处理实验**
 
（1）准备工作：新建解决方案，在解决方案下新建四个项目.其中第一个项目为CopyDataStruct，其输出类型为类库;第二个项目为SenderA，其输出类型为windows窗体应用(.NET Framework)或WPF应用(.NET Framework),第三个项目为ReceiverB, 其输出类型为windows窗体应用(.NET Framework)，第四个项目为ReceiverC, 其输出类型为WPF窗体应用(.NET Framework)；
（2）定义消息类型和消息结构：在项目CopyDataStruct中定义消息类型，定义消息结构体；
（3）实现消息发送者程序A：引用CopyDataStruct，声明User32.dll中的函数FindWindow，声明User32.dll中的函数SendMessage，定义窗体布局和控件元素，实现消息的封装及消息发送；
（4）实现winform窗体应用程序B：引用CopyDataStruct，重载实现winform窗体消息处理函数DefWndProc；
（5）实现wpf窗体应用程序C：引用CopyDataStruct，在wpf窗体加载事件中定义钩子函数，并实现该钩子函数。
  
  
  要求：
  
  功能性要求：
  
（1）窗体应用程序A通过文本输入框接收用户输入，通过文本框输入目标窗体应用B或C，并通过按钮触发消息发送给相应窗体应用程序B或C；
（2）窗体应用程序B为winform应用程序，在收到消息之后，在列表框中显示消息内容及接收时间；
（3）窗体应用程序C为wpf应用程序，在收到消息之后，在列表框中显示消息内容及接收时间。


  业务逻辑要求：
  
（1）按下“触发消息1”按钮后，发送消息，窗体winform程序接收消息并显示内容；
（2）按下“触发消息2”按钮后，发送消息，窗体wpf程序接收消息并显示内容。
