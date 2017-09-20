using MyAttribute.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 1 什么是attribute，和注释有什么区别
    /// 2 声明和使用attribute
    /// 3 使用attribute完成扩展
    /// 
    /// 特性：可以影响程序的编译和运行
    /// 
    /// 
    /// 特性：可以在不影响类型封装的前提下，给类额外的增加信息/行为。。。
    /// AOP：面向切面编程，就是在不影响原来类型封装的前提下，额外的切入新的功能
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班公开课之核心语法特训，今天是Eleven老师为大家带来的特性Attribute");

                Student free = new StudentOpen()
                {
                    Id = 11,
                    Name = "冰封",
                };

                Student vip = new StudentVip()
                {
                    Id = 919,
                    Name = "一般等价物"
                };
                Student vvip = new StudentVVip()
                {
                    Id = 589,
                    Name = "Byboy"
                };

                StudentManager.Manage(free);
                StudentManager.Manage(vip);
                StudentManager.Manage(vvip);

                Console.WriteLine(UserState.Normal.GetRemark());
                Console.WriteLine(UserState.Frozen.GetRemark());
                Console.WriteLine(UserState.Delete.GetRemark());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
