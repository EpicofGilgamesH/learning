using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// vip学员
    /// </summary>

    //[Custom]
    //[Custom()]
    //[Custom("这里是vip学员")]
    //[Custom(Remark = "Remark")]
    [Custom("这里是vip学员", Remark = "Remark")]
    //[CustomAttribute]
    //[CustomAttributeChild]
    public class StudentVip : Student
    {
         [Custom]
        [CustomAttributeChild]
        public override void Study()
        {
            Console.WriteLine("周二三四晚上八点到十点学习.net高级开发，五六日巩固练习和老师一对一批改");
        }

         public override void Show(int id)
         {
             Console.WriteLine("这里是vip学员");
         }
    }
}
