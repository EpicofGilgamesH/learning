﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 银行客户端  活期
    /// </summary>
    public class ClientCurrent : ClientBase
    {
        //活期  定期都有利息，但是利率不同
        public override double CalculateInterest(double balance)
        {
            return balance * 0.003;
        }

        //public override void Show(string name, double balance, double interest)
        //{
        //    Console.WriteLine("尊敬的{0}客户，你的账户余额为：{1}，利息为{2}",
        //        name, balance, interest);
        //}
    }
}
