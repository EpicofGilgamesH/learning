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
    [Custom("这里是vvip学员", Remark = "Remark")]
    //[CustomAttribute]
    //[CustomAttributeChild]
    public class StudentVVip : Student
    {
        [Custom]
        [CustomAttributeChild]
        public override void Study()
        {
            Console.WriteLine("任何时候学习任何课程");
        }
        public override void Show(int id)
        {
            Console.WriteLine("这里是vvip学员");
        }
    }
}
