using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Extend
{
    public static class ValidateExtend
    {
        public static bool Validate<T>(this T t)
        {
            Type type = t.GetType();
            foreach (var prop in type.GetProperties())
            {
                var array = prop.GetCustomAttributes(typeof(LongAttribute), true);
                if (array != null && array.Length > 0)
                {
                    LongAttribute attribute = array[0] as LongAttribute;
                    if (!attribute.Check((long)prop.GetValue(t)))
                        return false;
                }
            }
            return true;
        }
    }

    public class LongAttribute : Attribute
    {
        private long _Min = 0;
        private long _Max = 0;
        public LongAttribute(long min, long max)
        {
            this._Min = min;
            this._Max = max;
        }

        public bool Check(long lParameter)
        {
            return this._Min < lParameter && lParameter < this._Max;
        }
    }
}
