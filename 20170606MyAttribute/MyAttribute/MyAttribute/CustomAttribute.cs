using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 特性：是一个类，直接/间接继承自Attribute即可
    /// 约定俗成用attribute结尾，使用的时候可以省略掉Attribute
    /// </summary>

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute()
        {

        }

        public CustomAttribute(string description)
        {
            this.Description = description;
        }

        public string Description { get; private set; }

        public string Remark { get; set; }

        public void Log()
        {
            Console.WriteLine(this.Remark);
            Console.WriteLine("This is log");
        }
    }


    public class CustomAttributeChild : CustomAttribute
    {
    }
}
