using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 学生类，这里我可以随意添加注释
    /// 反正你也找不到我
    /// </summary>
    //[Obsolete("这里已经过期了", true)]
    [Serializable]
    public abstract class Student
    {
        //[Obsolete]
        public int Id { get; set; }
        //[NonSerialized]
        public string Name { get; set; }

        public virtual void Show(int id)
        { }

        public abstract void Study();
    }
}
