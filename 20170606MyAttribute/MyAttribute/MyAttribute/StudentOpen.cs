using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 公开课学员
    /// </summary>
    [Custom("这里是公开课学员", Remark = "Remark")]
    public class StudentOpen : Student
    {
        public override void Study()
        {
            Console.WriteLine("周一到六上午十点到十一点跟Eleven老师学习高级班公开课");
        }

        public override void Show(int id)
        {
            Console.WriteLine("这里是公开课学员");
        }
    }
}
