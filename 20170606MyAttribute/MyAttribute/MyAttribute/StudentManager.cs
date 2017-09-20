using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    public class StudentManager
    {
        /// <summary>
        /// 如果是公开课学员
        /// 如何是vip学员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void Manage<T>(T t) where T : Student
        {
            Console.WriteLine(t.Id);
            Console.WriteLine(t.Name);
            t.Study();

            t.Show(t.Id);//2 修改类，增加额外的逻辑，破坏封装

            //if (t is StudentOpen)//1 写死  不灵活
            //{
            //    Console.WriteLine("这里是公开课学员");
            //}
            //else if (t is StudentVip)
            //{
            //    Console.WriteLine("这里是vip学员");
            //}
            ////

            //log  Remark

            Type type = t.GetType();//3 通过特性
            object[] oAttributeArray = type.GetCustomAttributes(typeof(CustomAttribute), true);
            if (oAttributeArray != null && oAttributeArray.Length > 0)
            {
                foreach (var oAttribute in oAttributeArray)
                {
                    if (oAttribute is CustomAttribute)
                    {
                        CustomAttribute custom = (CustomAttribute)oAttribute;
                        Console.WriteLine(custom.Description);
                        custom.Log();

                    }
                }
            }

        }
    }
}
