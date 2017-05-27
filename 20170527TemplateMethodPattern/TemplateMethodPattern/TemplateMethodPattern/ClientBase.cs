using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 父类  抽象
    /// </summary>
    public abstract class ClientBase
    {
        /// <summary>
        /// 登陆查询功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        public void Query(int id, string name, string password)
        {
            if (this.CheckUser(id, password))
            {
                double balance = this.QueryBalance(id);
                double interest = this.CalculateInterest(balance);
                this.Show(name, balance, interest);
            }
            else
            {
                Console.WriteLine("账户密码错误");
            }
        }

        /// <summary>
        /// 用户检测
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckUser(int id, string password)
        {
            return DateTime.Now < DateTime.Now.AddDays(1);
        }

        /// <summary>
        /// 查询余额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double QueryBalance(int id)
        {
            return new Random().Next(10000, 1000000);
        }

        /// <summary>
        /// 获取利率，计算利息
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public abstract double CalculateInterest(double balance);
        //活期  0.003
        //定期  0.007

        //vip  0.011

        /// <summary>
        /// 展示下
        /// </summary>
        /// <param name="name"></param>
        /// <param name="balance"></param>
        /// <param name="interest"></param>
        //public void Show(string name, double balance, double interest)
        //{
        //    //if
        //    //else
        //    //定期 活期
        //    Console.WriteLine("尊敬的{0}客户，你的账户余额为：{1}，利息为{2}",
        //        name, balance, interest);

        //    //vip
        //    Console.WriteLine("尊贵的{0}客户，你的账户余额为：{1}，利息为{2}",
        //        name, balance, interest);
        //}
        //public abstract void Show(string name, double balance, double interest);
        public virtual void Show(string name, double balance, double interest)
        {
            Console.WriteLine("尊敬的{0}客户，你的账户余额为：{1}，利息为{2}",
                name, balance, interest);
        }
    }
}
