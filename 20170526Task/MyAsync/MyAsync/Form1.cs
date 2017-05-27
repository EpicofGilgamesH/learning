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
    /// 
    /// 1 异步的回调和状态参数
    /// 2 异步等待三种方式
    /// 3 获取异步的返回值
    /// 
    /// 1 回顾委托和异步多线程
    /// 2 通过Task启动多线程
    /// 3 解决多线程几大应用场景
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

        #region btnAsyncAdvanced_Click
        /// <summary>
        /// 1 异步的回调和状态参数
        /// 2 异步等待三种方式
        /// 3 获取异步的返回值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsyncAdvanced_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("******************btnAsyncAdvanced_Click 异步方法 start {0}********************", Thread.CurrentThread.ManagedThreadId);

            Action<string> act = new Action<string>(this.DoSomethingLong);

            ////AsyncCallback asyncCallback = new AsyncCallback(this.CustomCallback);
            ////iResult = act.BeginInvoke("btnAsyncAdvanced_Click", asyncCallback, "923-扬羽");
            //iResult = act.BeginInvoke("btnAsyncAdvanced_Click", null, null);

            ////int i = 0;
            ////while (!iResult.IsCompleted)//1 可以在等待的时候执行别的操作
            ////{
            ////    Thread.Sleep(200);//2 可能会最多损耗200ms的性能
            ////    if (i < 10)
            ////    {
            ////        Console.WriteLine("中华名族复兴已完成{0}%...", i++ * 10);
            ////    }
            ////    else
            ////    {
            ////        Console.WriteLine("中华民族复兴即将完成。。。。");
            ////    }
            ////}

            ////iResult.AsyncWaitHandle.WaitOne();//可以一直等待，直到完成
            ////iResult.AsyncWaitHandle.WaitOne(-1);//可以一直等待，直到完成
            ////iResult.AsyncWaitHandle.WaitOne(1000);//最多等待1000ms


            //act.EndInvoke(iResult);//直接等待，到地老天荒

            //Console.WriteLine("中华民族复兴已完成，颤栗吧！");
            //Console.WriteLine("这里是异步完成之后才会做的事儿 {0}", Thread.CurrentThread.ManagedThreadId);

            Func<string, int> func = new Func<string, int>(s =>
            {
                Thread.Sleep(3000);
                return s.Length + DateTime.Now.Day;
            });//lambda

            //IAsyncResult iResultFunc = func.BeginInvoke("jim", null, null);
            IAsyncResult iResultFunc = func.BeginInvoke("jim", t =>
            {
                int i = func.EndInvoke(t);//对于每个异步操作，只能调用一次 EndInvoke。
            }, null);

            int intResult = func.EndInvoke(iResultFunc);//除了等待，还可以获取委托本身调用的返回值
            Console.WriteLine("intResult={0}", intResult);

            Console.WriteLine("******************btnAsyncAdvanced_Click 异步方法 end   {0}********************", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
        }

        private IAsyncResult iResult = null;

        private void CustomCallback(IAsyncResult iAsyncResult)
        {
            Console.WriteLine(iAsyncResult.AsyncState);
            Console.WriteLine("CustomCallback 被调用了，{0}", Thread.CurrentThread.ManagedThreadId);
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

        #region btnTask_Click
        //委托的异步调用  Thread  ThreadPool  Task await/async Parallel

        /// <summary>
        /// 1 回顾委托和异步多线程
        /// 2 通过Task启动多线程
        /// 3 解决多线程几大应用场景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTask_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("******************btnTask_Click 异步方法 start {0}********************", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Eleven老师接到一个私活");
            Console.WriteLine("沟通需求，谈妥价格");
            Console.WriteLine("签合同，收取50%的费用");
            Console.WriteLine("高级班筛选学员，组建团队");
            Console.WriteLine("需求分析、系统设计、框架搭建、模块划分");
            Console.WriteLine("开始干活。。。");

            //多人共同协作，不再我一个人孤军奋战   开始多线程

            TaskFactory taskFactory = new TaskFactory();

            //Action act = new Action(
            //    () =>
            //    {
            //        this.Coding("CSS", "Protal");
            //    });
            //act.BeginInvoke(null, null);

            List<Task> taskList = new List<Task>();
            //CancellationTokenSource
            taskList.Add(taskFactory.StartNew(() => this.Coding("CSS", "Protal")));
            taskList.Add(taskFactory.StartNew(() => this.Coding("一生有意义", "Client")));
            taskList.Add(taskFactory.StartNew(() => this.Coding("一剑", "WechatClient")));
            taskList.Add(taskFactory.StartNew(() => this.Coding("Jim", "WCF")));
            taskList.Add(taskFactory.StartNew(() => this.Coding("幸福你我", "EBack")));
            taskList.Add(taskFactory.StartNew(() => this.Coding("小画家", "DBA")));

            //6个人  全部完成后，进入联调测试
            taskList.Add(taskFactory.ContinueWhenAll(taskList.ToArray(), tList => Console.WriteLine("部署、联调、测试")));

            //6个人 谁先完成，谁获取红包
            taskList.Add(taskFactory.ContinueWhenAny(taskList.ToArray(), t => Console.WriteLine("获取红包奖励")));

            //Task.WaitAny()//只传一个task进去就可以了
            Task.WaitAny(taskList.ToArray());//让当前线程等待某个task的完成
            //线程等待，需要某个任务完成后，收钱
            Console.WriteLine("完成一个模块，开始部署测试的时候，收取20%");

            Task.WaitAll(taskList.ToArray());//让当前线程等待全部task的完成
            //Thread.Sleep(100);
            //线程等待，需要等着6个任务都完成之后
            Console.WriteLine("开发都完成，验收通过后，再收取30%");
            Console.WriteLine("分钱分钱。。。");
            Console.WriteLine("******************btnTask_Click 异步方法 end   {0}********************", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
        }

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="name"></param>
        /// <param name="project"></param>
        private void Coding(string name, string project)
        {

            Console.WriteLine("******************Coding start {0} {1} {2} {3}********************",
                name, project, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"));

            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine("******************Coding   end {0} {1} {2} {3}********************",
                name, project, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"));
        }
        #endregion
    }
}
