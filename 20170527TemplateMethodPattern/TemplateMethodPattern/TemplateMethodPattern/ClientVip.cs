using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 银行客户端  vip
    /// </summary>
    public class ClientVip : ClientBase
    {
        public override double CalculateInterest(double balance)
        {
            return balance * 0.011;
        }

        /// <summary>
        /// 包含大部分场景的默认实现，但是又要留下扩展
        /// </summary>
        /// <param name="name"></param>
        /// <param name="balance"></param>
        /// <param name="interest"></param>
        public override void Show(string name, double balance, double interest)
        {
            Console.WriteLine("尊贵的{0}客户，你的账户余额为：{1}，利息为{2}",
                name, balance, interest);
        }
    }
}
