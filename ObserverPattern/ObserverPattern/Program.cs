using ObserverPattern.Observer;
using ObserverPattern.Subject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    /// <summary>
    /// 1 观察者模式Observer
    /// 2 .net的委托事件
    /// 3 观察者模式的应用
    /// </summary>
    static class Program
    {
        public static dynamic ToDynamic(this object value)
        {
            IDictionary<string, object> expando = new ExpandoObject();
            Type type = value.GetType();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(type);
            foreach (PropertyDescriptor property in properties)
            {
                var val = property.GetValue(value);
                if (property.PropertyType.FullName.StartsWith("<>f__AnonymousType"))
                {
                    dynamic dval = val.ToDynamic();
                    expando.Add(property.Name, dval);
                }
                else
                {
                    expando.Add(property.Name, val);
                }
            }
            return expando as ExpandoObject;
        }


        public static T GetAttribute<T>(this MemberInfo memberInfo, bool inherit = false) where T : Attribute
        {
            var descripts = memberInfo.GetCustomAttributes(typeof(T), inherit);
            return descripts.FirstOrDefault() as T;
        }


        static void Main(string[] args)
        {

            var data = new { Name = "Kaakar", Age = "18" };
            dynamic result = data.ToDynamic();
            Console.WriteLine(result.Name);
            Console.WriteLine(result.Age);
            //Console.WriteLine(result.Error);

            ABC abc = new ABC();
            abc.Name = "jack";

            Type abctype = typeof(ABC);
            DescriptionAttribute da = abctype.GetAttribute<DescriptionAttribute>(false);
            string des = da.Description;

            Type tp = abc.Name.GetType();
            DescriptionAttribute d = tp.GetAttribute<DescriptionAttribute>(false);
            string de = d.Description;

            Console.ReadKey();

            #region
            //    try
            //    {
            //        Console.WriteLine("欢迎来到.net高级班公开课之设计模式特训，今天是Eleven老师为大家带来的观察者模式");

            //        {
            //            Cat cat = new Cat();
            //            cat.Miao();
            //        }
            //        Console.WriteLine("*******************************");
            //        {
            //            Cat cat = new Cat();

            //            cat.Add(new Baby());
            //            cat.Add(new Brother());
            //            cat.Add(new Chicken());
            //            cat.Add(new Dog());
            //            cat.Add(new Father());
            //            cat.Add(new Mother());
            //            cat.Add(new Mouse());
            //            cat.Add(new Neighbor());
            //            cat.Add(new Stealer());

            //            cat.MiaoObserver();
            //        }
            //        Console.WriteLine("*******************************");
            //        {
            //            Cat cat = new Cat();

            //            //cat.Add(new Baby());
            //            cat.Add(new Chicken());
            //            cat.Add(new Brother());
            //            cat.Add(new Dog());
            //            cat.Add(new Father());
            //            cat.Add(new Mother());
            //            cat.Add(new Mouse());
            //            cat.Add(new Neighbor());
            //            cat.Add(new Stealer());

            //            cat.MiaoObserver();
            //        }
            //        Console.WriteLine("*******************************");
            //        {
            //            Cat cat = new Cat();

            //            cat.MiaoHandler += () => new Baby().Cry(5);
            //            cat.MiaoHandler += new Chicken().Woo;
            //            cat.MiaoHandler += new Brother().Turn;
            //            cat.MiaoHandler += new Dog().Wang;
            //            cat.MiaoHandler += new Father().Roar;
            //            cat.MiaoHandler += new Mother().Whisper;
            //            cat.MiaoHandler += new Mouse().Run;
            //            cat.MiaoHandler += new Neighbor().Awake;
            //            cat.MiaoHandler += new Stealer().Hide;

            //            cat.MiaoEvent();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //    Console.Read();
            //}
            #endregion
        }
    }

    [Description("ABC类")]
    public class ABC
    {
        [Description("姓名")]
        public string Name { get; set; }

        [Description("年龄")]
        public int Age { get; set; }
    }
}
