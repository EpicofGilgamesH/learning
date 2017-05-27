using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 1  抽象方法/虚方法/普通方法
    /// 2  模板方法设计模式
    /// 3  钩子方法
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班公开课之设计模式特训，今天是Eleven老师为大家带来的模板方法模式");
                //MethodTest.Show();
                {
                    ClientBase client = new ClientCurrent();
                    client.Query(133, "一剑", "888888");
                }

                {
                    ClientBase client = new ClientRegular();
                    client.Query(724, "jim", "913099");
                }
                {
                    ClientBase client = new ClientVip();
                    client.Query(858, "幸福你我", "678932");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
