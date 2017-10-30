using MessageLog;
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
        private static eventID eventID = eventID.TReport_TRExpression;
        
        /// <summary>
        /// Перечень операторов
        /// </summary>
        public enum Operation : int
        {
            add = 1, ded = 2, mul = 3, div = 4, mod=5
        }
        /// <summary>
        /// класс данных Expression
        /// </summary>
        public class Expression
        {
            public object value { get; set; }
        }
        /// <summary>
        /// преобразовать значения
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double? ConvertDouble(this object val)
        {
            try
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
                if (val is int) { 
                    return (double?)(int?)val;                
                }
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("ConvertDouble(val={0}", val), eventID);
            }
            return null;
        }
        /// <summary>
        /// Выполнить указаное вычисление переменых 
        /// </summary>
        /// <param name="expresions"></param>
        /// <param name="oper"></param>
        /// <returns></returns>
        public static List<Expression> CalcExpression(this List<Expression> expresions, Operation oper)
        {
            try{
            double? val1 = null;
            double? val2 = null;
            int index = 0;
            while (index < expresions.Count())
            {
                if (expresions[index].value is Operation && (Operation)expresions[index].value == oper)
                {
                    if (!(expresions[index - 1].value is Operation) && expresions[index - 1].value != DBNull.Value)
                    {
                        val1 = expresions[index - 1].value.ConvertDouble();
                    }
                    if (!(expresions[index + 1].value is Operation) && expresions[index + 1].value != DBNull.Value)
                    {
                        val2 = expresions[index + 1].value.ConvertDouble();
                    }
                    if (val1 != null && val2 != null)
                    {

                        switch (oper)
                        {
                            case Operation.mul: expresions[index - 1].value = val1 * val2; break;
                            case Operation.div: expresions[index - 1].value = val1 / val2; break;
                            case Operation.mod: expresions[index - 1].value = val1 % val2; break;
                            case Operation.add: expresions[index - 1].value = val1 + val2; break;
                            case Operation.ded: expresions[index - 1].value = val1 - val2; break;
                        }
                        expresions.Remove(expresions[index]);
                        expresions.Remove(expresions[index]);
                        index--;
                    }
                }
                index++;
            }

            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("CalcExpression(expresions={0}, oper={1})", expresions, oper), eventID);
            }
            return expresions;
        }
        /// <summary>
        /// Произвести вычисление ответления скобок списка переменных
        /// </summary>
        /// <param name="expresions"></param>
        /// <returns></returns>
        public static object CalcExpression(ref List<Expression> expresions)
        {
            try
            {
                List<Expression> line = new List<Expression>();
                foreach (Expression ex in expresions)
                {
                    if (ex.value is IEnumerable)
                    {
                        List<Expression> new_line = (List<Expression>)ex.value;
                        object res = CalcExpression(ref new_line);
                        line.Add(new Expression() { value = res });
                    }
                    else
                    {
                        line.Add(ex);
                    }

                }
                List<Expression> list_result = line.ToList().CalcExpression(Operation.mul).CalcExpression(Operation.div).CalcExpression(Operation.mod).CalcExpression(Operation.add).CalcExpression(Operation.ded);
                return list_result != null && list_result.Count() > 0 ? list_result[0].value : null;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("CalcExpression(expresions={0}", expresions), eventID);
                return null;
            }
        }
        /// <summary>
        /// Произвести вычисление списка переменных
        /// </summary>
        /// <param name="expresions"></param>
        /// <returns></returns>
        public static object CalcExpressions(this List<Expression> expresions) {
            object value = CalcExpression(ref expresions);
            return value;
        }
        /// <summary>
        /// Получить значение поля тега
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="Row"></param>
        /// <returns></returns>
        public static object GetValue(this string tag, DataRow Row)
        {
            if (String.IsNullOrWhiteSpace(tag)) return null;
            object value = null;
            try { value = Row[tag.Trim()]; }
            catch (Exception e)
            {
                try { value = (object)double.Parse(tag.Trim(), CultureInfo.CreateSpecificCulture("en-US")); }
                catch (Exception ex)
                {
                    value = null;
                }
            }
            return value;
        }
        /// <summary>
        /// Список переменных и операций с учетом скобок
        /// </summary>
        /// <param name="expresions"></param>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="Row"></param>
        public static void GetExpression(ref List<Expression> expresions, char[] array, ref int index, DataRow Row)
        {
            try
            {
                object value = null;
                string tags = null;
                while (index < array.Count())
                {
                    char c = array[index];
                    index++;
                    if (!"+-*%/()".Contains(c))
                    {
                        tags += c;
                    }
                    else
                    {
                        value = GetValue(tags, Row);
                        if (value != null)
                        {
                            expresions.Add(new Expression() { value = value });
                            tags = null; // обнулим название тега
                        }
                        if ("+-*%/".Contains(c))
                        {

                            switch (c)
                            {
                                case '+': expresions.Add(new Expression() { value = Operation.add }); break;
                                case '-': expresions.Add(new Expression() { value = Operation.ded }); break;
                                case '*': expresions.Add(new Expression() { value = Operation.mul }); break;
                                case '/': expresions.Add(new Expression() { value = Operation.div }); break;
                                case '%': expresions.Add(new Expression() { value = Operation.mod }); break;
                            }
                        }
                        else
                        {
                            if (c == '(')
                            {
                                List<Expression> new_expresions = new List<Expression>();
                                GetExpression(ref new_expresions, array, ref index, Row);
                                expresions.Add(new Expression() { value = new_expresions });
                            }
                            if (c == ')')
                            {
                                //expresions.Add(new Expression() { value = new_expresions });
                                return;
                            }
                        }
                    }
                }
                value = GetValue(tags, Row);
                if (value != null)
                {
                    expresions.Add(new Expression() { value = value });
                }
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetExpression(expresions={0}, array={1}, index={2}, Row={3})", expresions, array, index, Row), eventID);

            }
            return;
        }
        /// <summary>
        /// Получить результат вычисления над тегами
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="Row"></param>
        /// <returns></returns>
        public static object GetExpression(this string tag, DataRow Row)
        {
            
            if (string.IsNullOrWhiteSpace(tag) || Row==null) return null;
            try
            {
                if (!tag.Contains("=")) return Row != null ? Row[tag.Trim()] : null;
                //tag = "=GL_FCDL+GR_FCDR+(45.78+67*(GL_FCDL*2)-(GR_FCDR/7)+45)";
                //tag = "=11+(22-44)*(66+77)";
                List<Expression> expresions = new List<Expression>();
                char[] array = tag.ToCharArray();
                int index = 1; // начнем за символом =
                GetExpression(ref expresions, array, ref index, Row);
                return expresions.CalcExpressions();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetExpression(tag={0}, Row={1})", tag, Row), eventID);
                return null;
            }
        }
        

    }
    
}
