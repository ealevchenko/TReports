using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

    public static class TRExpression
    {

        public enum expression : int
        {
            tag = 0, instruction = 1
        }

        public class ExpressionValue
        {
            public string tag { get; set; }
            public object val { get; set; }
            public int order { get; set; }
            public expression expression { get; set; }
        }

        public static List<ExpressionValue> GetExpressionValue(this string tag)
        {
            List<ExpressionValue> list = new List<ExpressionValue>();
            if (string.IsNullOrWhiteSpace(tag) || !tag.Contains("=")) return list;
            char[] array = tag.ToCharArray();
            string tags = null;
            int order = 0;
            foreach (char c in array)
            {
                if (c != '=')
                {
                    if (!"+-*/()".Contains(c))
                    {
                        tags += c;
                    }
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(tags))
                        {
                            list.Add(new ExpressionValue() { tag = tags, expression = expression.tag, order = order});
                        }
                        if ("+-*/".Contains(c))
                        {
                            list.Add(new ExpressionValue() { tag = c.ToString(), expression = expression.instruction, order = order });
                        }
                        else {
                            if (c == '(') order++;
                            if (c == ')') order--;
                        }
                        
                        tags = null;
                    }
                }
            }
            if (!String.IsNullOrWhiteSpace(tags))
            {
                list.Add(new ExpressionValue() { tag = tags, expression = expression.tag, order = order });
            }
            return list;
        }

        public static double? ConvertDouble(this object val)
        {
            if (val is System.Double)
            {
                return (double?)val;
            }
            if (val is System.Single)
            {
                return (double?)(Single?)val;
            }
            if (val is float)
            {
                return (double?)(float?)val;
            }
            if (val is decimal)
            {
                return (double?)(decimal?)val;
            }
            return null;
        }

        public static List<ExpressionValue> GetExpression(this List<ExpressionValue> list, char instruction)
        {
            if (!"+-/*".Contains(instruction)) return list;
            double? val1 = null;
            double? val2 = null;
            int index = 0;
            while (index < list.Count())
            {
                if (list[index].expression == expression.instruction && list[index].tag == instruction.ToString())
                {
                    if (list[index - 1].expression == expression.tag && list[index - 1].val != DBNull.Value)
                    {
                        val1 = list[index - 1].val.ConvertDouble();
                    }
                    if (list[index + 1].expression == expression.tag && list[index + 1].val != DBNull.Value)
                    {
                        val2 = list[index + 1].val.ConvertDouble();
                    }
                    if (val1 != null && val2 != null)
                    {

                        switch (instruction)
                        {
                            case '*': list[index - 1].val = val1 * val2; break;
                            case '/': list[index - 1].val = val1 / val2; break;
                            case '+': list[index - 1].val = val1 + val2; break;
                            case '-': list[index - 1].val = val1 - val2; break;
                        }
                        list.Remove(list[index]);
                        list.Remove(list[index]);
                    }
                }
                index++;
            }
            return list;
        }

        public static void GetExpression(ref List<ExpressionValue> list)
        {
            if (list != null && list.Count() > 1)
            {
                List<IGrouping<int, ExpressionValue>> group = list.GroupBy(o => o.order).OrderByDescending(o => o.Key).ToList();
                IGrouping<int, ExpressionValue> gr_end = group.FirstOrDefault();
                //List<ExpressionValue> list_result = gr_end.ToList();
                List<ExpressionValue> list_result = gr_end.ToList().GetExpression('*').GetExpression('/').GetExpression('+').GetExpression('-');
                object result = list_result != null && list_result.Count() > 0 ? list_result[0].val : null;
                ExpressionValue ev_new = new ExpressionValue() { expression = expression.tag, val = result, order = gr_end.Key - 1, tag = "()" };
                bool bdel = true;
                foreach (ExpressionValue ev in list.ToList())
                {
                    if (ev.order == gr_end.Key)
                    {
                        if (bdel)
                        {
                            ev.val = ev_new.val;
                            ev.order = ev.order - 1;
                            ev.tag = "()"; bdel = false;
                        }
                        else
                            list.Remove(ev);
                    }
                }
                GetExpression(ref list);
            }

        }

        public static object GetExpressions(this List<ExpressionValue> list)
        {
            GetExpression(ref list);
            return list != null && list.Count() > 0 ? list[0].val : null;
        }
        /// <summary>
        /// Получить значение выражения по имени тега или последовательности операции над тегами
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="Row"></param>
        /// <returns></returns>
        public static object GetExpression(this string tag, DataRow Row)
        {
            if (tag.Contains("="))
            {
                List<ExpressionValue> list_exp = tag.GetExpressionValue();
                foreach (ExpressionValue ev in list_exp.Where(e => e.expression == expression.tag))
                {
                    try { ev.val = Row != null ? Row[ev.tag.Trim()] : null; }
                    catch (Exception e)
                    {
                        try { ev.val = (object)double.Parse(ev.tag.Trim(), CultureInfo.CreateSpecificCulture("en-US")); }
                        catch (Exception ex)
                        {
                            ev.val = null;
                        }
                    }
                }
                return list_exp.GetExpressions();
            }
            else
            {
                return Row != null   ? Row[tag.Trim()] : null;
            }
        }

    }
    
}
