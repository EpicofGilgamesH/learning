using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Extend
{
    /// <summary>
    /// 备注特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class RemarkAttribute : Attribute
    {
        public RemarkAttribute(string remark)
        {
            this.Remark = remark;
        }

        public string Remark
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class RemarkExtend
    {
        /// <summary>
        /// 获取枚举的备注
        /// </summary>
        /// <param name="eValue"></param>
        /// <returns></returns>
        //[return RemarkAttribute()]
        public static string GetRemark(this Enum eValue)
        {
            try
            {
                Type type = eValue.GetType();
                FieldInfo field = type.GetField(eValue.ToString());
                RemarkAttribute remarkAttribute = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute));
                if (remarkAttribute == null)
                    return field.ToString();
                else
                    return remarkAttribute.Remark;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return eValue.ToString();
        }
    }

    [Remark("用户状态")]
    public enum UserState
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Remark("正常")]
        Normal = 0,
        /// <summary>
        /// 冻结
        /// </summary>
        [Remark("冻结")]
        Frozen = 1,
        /// <summary>
        /// 删除
        /// </summary>
        [Remark("删除")]
        Delete = 2,

        //UnAudit = 3
    }
}
