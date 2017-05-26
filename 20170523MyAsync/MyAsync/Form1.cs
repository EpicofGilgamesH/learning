using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAsync
{
    /// <summary>
    /// 1 进程、线程、同步、异步的概念
    /// 2 回顾委托，开始异步
    /// 3 异步的三大特点
    /// </summary>
    public partial class frmAsync : Form
    {
        public frmAsync()
        {
            Console.WriteLine("欢迎来到.net高级班公开课之核心语法特训，今天是Eleven老师为大家带来的异步多线程");
            InitializeComponent();
        }

        #region btnSync_Click
        /// <summary>
        /// 同步方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("******************btnSync_Click 同步方法 start {0}********************", Thread.CurrentThread.ManagedThreadId);
            int j = 0;
            int k = 1;
            int m = j + k;
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("{0}_{1}", "btnSync_Click", i);
                this.DoSomethingLong(name);
            }

            Console.WriteLine("******************btnSync_Click 同步方法 end   {0}********************", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
        }
        #endregion

        #region btnAsync_Click

        private delegate void TestHandler(string methodName);//1 声明委托

        /// <summary>
        /// 委托的异步调用
        /// 1 同步方法卡界面，原因是UI线程忙于计算；异步多线程方法不卡界面，原因是UI线程空闲，计算交给子线程完成
        /// 2 同步方法慢，原因是只有一个线程计算；异步多线程方法快，原因是多个线程同时计算，会消耗更多的资源（线程不是越多越好）
        /// 3 异步多线程方法是无序的：启动无序、计算无序、结束无序，不要试图控制多线程顺序，只能通过回调/等待
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("******************btnAsync_Click 异步方法 start {0}********************", Thread.CurrentThread.ManagedThreadId);
            TestHandler method = new TestHandler(this.DoSomethingLong);//2 实例化委托
            //method.Invoke("btnAsync_Click");//3 委托实例的调用   同步的

            //method.BeginInvoke("btnAsync_Click", null, null);

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("{0}_{1}", "btnAsync_Click", i);
                method.BeginInvoke(name, null, null);
            }

            Console.WriteLine("******************btnAsync_Click 异步方法 end   {0}********************", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// 一个耗时耗资源的测试方法
        /// </summary>
        /// <param name="name"></param>
        private void DoSomethingLong(string name)
        {
            Console.WriteLine("******************DoSomethingLong start {0} {1} {2}********************",
                name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"));

            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }

            Console.WriteLine("******************DoSomethingLong   end {0} {1} {2} {3}********************",
                name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"), lResult);
        }
        #endregion
    }
}
