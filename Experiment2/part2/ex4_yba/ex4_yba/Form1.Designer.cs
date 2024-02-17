using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public delegate void OutputHandler(string message);

public class Producer
{
    Semaphore sema;
    List<string> list;
    int id;
    public event OutputHandler result;

    public Producer(Semaphore sema, List<string> list, int id)
    {
        this.sema = sema;
        this.list = list;
        this.id = id;
    }

    public void produce()
    {
        Thread.Sleep(1000);
        sema.WaitOne();
        int data = (new Random().Next());
        string str = data.ToString();
        result($"Produce{id}: {str}\n");
        SaveData(data);
        sema.Release();
    }

    public void SaveData(int res)
    {
        list.Add(res.ToString());
    }
}

public class Customer
{
    Semaphore sema;
    List<string> list;
    int id;
    public event OutputHandler data;

    public Customer(Semaphore sema, List<string> list, int id)
    {
        this.sema = sema;
        this.list = list;
        this.id = id;
    }

    public void consume()
    {
        Thread.Sleep(1000);
        sema.WaitOne();
        if (list.Count == 0)
        {
            data($"Consumer{id}:no product to consume.\n");
        }
        else
        {
            data($"Consumer{id}: {list.First()}\n");
            list.RemoveAt(0);
        }
        sema.Release();
    }
}

public partial class Form1 : Form
{
    bool pro = true;
    bool con = true;
    List<string> list = new List<string>();
    Semaphore sema = new Semaphore(1, 1);

    public Form1()
    {
        InitializeComponent();
        Control.CheckForIllegalCrossThreadCalls = false;
    }
    private void InitializeComponent()
    {
        this.richTextBox1 = new System.Windows.Forms.RichTextBox();
        this.richTextBox2 = new System.Windows.Forms.RichTextBox();
        this.richTextBox3 = new System.Windows.Forms.RichTextBox();
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button3 = new System.Windows.Forms.Button();
        this.button4 = new System.Windows.Forms.Button();
        this.button5 = new System.Windows.Forms.Button();
        this.button6 = new System.Windows.Forms.Button();
        this.button7 = new System.Windows.Forms.Button();
        this.button8 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // richTextBox1
        // 
        this.richTextBox1.Location = new System.Drawing.Point(12, 12);
        this.richTextBox1.Name = "richTextBox1";
        this.richTextBox1.Size = new System.Drawing.Size(202, 282);
        this.richTextBox1.TabIndex = 0;
        this.richTextBox1.Text = "";
        // 
        // richTextBox2
        // 
        this.richTextBox2.Location = new System.Drawing.Point(288, 12);
        this.richTextBox2.Name = "richTextBox2";
        this.richTextBox2.Size = new System.Drawing.Size(202, 282);
        this.richTextBox2.TabIndex = 1;
        this.richTextBox2.Text = "";
        // 
        // richTextBox3
        // 
        this.richTextBox3.Location = new System.Drawing.Point(566, 12);
        this.richTextBox3.Name = "richTextBox3";
        this.richTextBox3.Size = new System.Drawing.Size(202, 282);
        this.richTextBox3.TabIndex = 2;
        this.richTextBox3.Text = "";
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(23, 301);
        this.button1.Name = "1开始生产";
        this.button1.Size = new System.Drawing.Size(75, 23);
        this.button1.TabIndex = 3;
        this.button1.Text = "1开始生产";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(23, 345);
        this.button2.Name = "2开始生产";
        this.button2.Size = new System.Drawing.Size(75, 23);
        this.button2.TabIndex = 4;
        this.button2.Text = "2开始生产";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // button3
        // 
        this.button3.Location = new System.Drawing.Point(163, 301);
        this.button3.Name = "3开始生产";
        this.button3.Size = new System.Drawing.Size(75, 23);
        this.button3.TabIndex = 5;
        this.button3.Text = "3开始生产";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new System.EventHandler(this.button3_Click);
        // 
        // button4
        // 
        this.button4.Location = new System.Drawing.Point(163, 345);
        this.button4.Name = "4开始生产";
        this.button4.Size = new System.Drawing.Size(75, 23);
        this.button4.TabIndex = 6;
        this.button4.Text = "4开始生产";
        this.button4.UseVisualStyleBackColor = true;
        this.button4.Click += new System.EventHandler(this.button4_Click);
        // 
        // button5
        // 
        this.button5.Location = new System.Drawing.Point(358, 301);
        this.button5.Name = "1开始消费";
        this.button5.Size = new System.Drawing.Size(75, 23);
        this.button5.TabIndex = 7;
        this.button5.Text = "1开始消费";
        this.button5.UseVisualStyleBackColor = true;
        this.button5.Click += new System.EventHandler(this.button5_Click);
        // 
        // button6
        // 
        this.button6.Location = new System.Drawing.Point(358, 345);
        this.button6.Name = "2开始消费";
        this.button6.Size = new System.Drawing.Size(75, 23);
        this.button6.TabIndex = 8;
        this.button6.Text = "2开始消费";
        this.button6.UseVisualStyleBackColor = true;
        this.button6.Click += new System.EventHandler(this.button6_Click);
        // 
        // button7
        // 
        this.button7.Location = new System.Drawing.Point(635, 301);
        this.button7.Name = "终止生产";
        this.button7.Size = new System.Drawing.Size(75, 23);
        this.button7.TabIndex = 9;
        this.button7.Text = "终止生产";
        this.button7.UseVisualStyleBackColor = true;
        this.button7.Click += new System.EventHandler(this.button7_Click);
        // 
        // button8
        // 
        this.button8.Location = new System.Drawing.Point(635, 345);
        this.button8.Name = "终止消费";
        this.button8.Size = new System.Drawing.Size(75, 23);
        this.button8.TabIndex = 10;
        this.button8.Text = "终止消费";
        this.button8.UseVisualStyleBackColor = true;
        this.button8.Click += new System.EventHandler(this.button8_Click);
        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(792, 397);
        this.Controls.Add(this.button8);
        this.Controls.Add(this.button7);
        this.Controls.Add(this.button6);
        this.Controls.Add(this.button5);
        this.Controls.Add(this.button4);
        this.Controls.Add(this.button3);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.richTextBox3);
        this.Controls.Add(this.richTextBox2);
        this.Controls.Add(this.richTextBox1);
        this.Name = "Form1";
        this.ResumeLayout(false);

    }
    public void writeTextBox1(string s)
    {
        this.richTextBox1.AppendText(s);
        richTextBox1.ScrollToCaret();
    }

    public void writeTextBox2(string s)
    {
        this.richTextBox2.AppendText(s);
        richTextBox2.ScrollToCaret();
    }

    public void writeTextBox3(string s)
    {
        this.richTextBox3.AppendText(s);
        richTextBox3.ScrollToCaret();
    }


    private void button1_Click(object sender, EventArgs e)
    {
        pro = true;
        new Task(() =>
        {
            Producer p1 = new Producer(sema, list, 1);
            p1.result += writeTextBox1;
            while (pro)
            {
                p1.produce();
            }
        }).Start();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        pro = true;
        new Task(() =>
        {
            Producer p2 = new Producer(sema, list, 2);
            p2.result += writeTextBox1;
            while (pro)
            {
                p2.produce();
            }
        }).Start();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        pro = true;
        new Task(() =>
        {
            Producer p3 = new Producer(sema, list, 3);
            p3.result += writeTextBox1;
            while (pro)
            {
                p3.produce();
            }
        }).Start();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        pro = true;
        new Task(() =>
        {
            Producer p4 = new Producer(sema, list, 4);
            p4.result += writeTextBox1;
            while (pro)
            {
                p4.produce();
            }
        }).Start();
    }
    private void button5_Click(object sender, EventArgs e)
    {
        con = true;
        new Task(() =>
        {
            Customer c1 = new Customer(sema, list, 1);
            c1.data += writeTextBox2;
            while (con)
            {
                c1.consume();
            }
        }).Start();
    }

    private void button6_Click(object sender, EventArgs e)
    {
        con = true;
        new Task(() =>
        {
            Customer c2 = new Customer(sema, list, 2);
            c2.data += writeTextBox3;
            while (con)
            {
                c2.consume();
            }
        }).Start();
    }

    private void button7_Click(object sender, EventArgs e)
    {
        pro = false;
    }

    private void button8_Click(object sender, EventArgs e)
    {
        con = false;
    }

    private RichTextBox richTextBox1;
    private RichTextBox richTextBox2;
    private RichTextBox richTextBox3;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private Button button5;
    private Button button6;
    private Button button7;
    private Button button8;
}
