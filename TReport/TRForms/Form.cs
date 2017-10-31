using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TReport.TData;
using TReport.App_LocalResources;
using Measurement;
using System.Globalization;
namespace TReport.TRForms
{
    interface IObject
    {
        string Object { get; }
    }

    /// <summary>
    /// Класс наименование 
    /// </summary>
    public class ObjectName
    {
        public string name_ru { get; set; }
        public string name_en { get; set; }
        public string name_uk { get; set; }
        public ObjectName() { }
        public string name
        {
            get
            {
                switch (CultureInfo.CurrentUICulture.Name)
                {
                    case "en-US": return this.name_en;
                    case "uk-UA": return this.name_uk;
                    default: return this.name_ru;
                }
            }
        }
    }
    
    public class Form
    {
        public string name { get; set; }
        public List<Group> Groups { get; set; }
        public Form() { }
    }

    public class Group : ObjectName
    {
        public int position { get; set; }
        public List<Type> Types { get; set; }
        public bool totals  { get; set; }
        public bool visible  { get; set; }
        public Group() { }
        public double SumValue(int position, int trobj)
        {
            double res = 0;
            foreach (Type val in Types)
            {
                res += val.SumValue(position, trobj);
            }
            return res;
        }
    }

    public class Type : ObjectName
    {
        public int position { get; set; }
        public List<Item> Items { get; set; }
        public bool totals { get; set; }
        public bool visible { get; set; }
        public Type() { }
        public double SumValue(int position, int trobj)
        {
            double res = 0;
            foreach (Item val in Items)
            {
                res += val.SumValue(position, trobj);
            }
            return res;
        }
    }

    public class Item : ObjectName
    {
        public int position { get; set; }
        public List<ItemObject> ItemObjects { get; set; }
        public Item() { }
        public double SumValue(int position, int trobj)
        {
            double res = 0;
            foreach (ItemObject val in ItemObjects)
            {
                if (val.trobj == trobj)
                {
                    res += val.SumValue(position);
                }
            }
            return res;
        }
    }

    public class ItemObject : IObject
    {
        public int trobj { get; set; }
        public List<ItemValue> ItemValues { get; set; }
        public string Object
        {
            get { return ((trObj)this.trobj).ToString().GetResources(); }
        }
        public ItemObject() { }
        public double SumValue(int position)
        {
            double res = 0;
            foreach (ItemValue val in ItemValues)
            {
                res += val.SumValue(position);
            }
            return res;
        }
    }

    public class ItemValue                     // Однострочный-многострочный
    {
        public object Key { get; set; }                // онострочный значение null
        public List<Value> Values { get; set; }
        public ItemValue() { }
        public double SumValue(int position)
        {
            double res = 0;
            foreach (Value val in Values)
            {
                if (val.position == position)
                {
                    object valobj = val.value != null ? ((DBValueMeasurement)val.value).Value : null;
                    res += valobj != null ? (double)valobj.ConvertDouble() : 0;
                }
            }
            return res;
        }
    }

    public class Value
    {
        public int tag { get; set; }
        public int? unit { get; set; }
        public int? multiplier { get; set; }
        public int position { get; set; }
        public object value { get; set; }
        public Value() { }
    }

}
