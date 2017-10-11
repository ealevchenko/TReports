using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport
{
    public static class TRConvert
    {
        public static bool In<T>(this T source, params T[] list)
        {
            return list.Contains(source);
        }

        public static string IntsToString(this IEnumerable<int> source, char sep)
        {
            string list = "";
            foreach (int i in source)
            {
                list += i.ToString() + sep;
            }
            return list.Remove(list.Length - 1);
        }
    }
}
