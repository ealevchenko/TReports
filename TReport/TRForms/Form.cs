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
        public Group() { }
    }

    public class Type : ObjectName
    {
        public int position { get; set; }
        public List<Item> Items { get; set; }
        public Type() { }
    }

    public class Item : ObjectName
    {
        public int position { get; set; }
        public List<ItemObject> ItemObjects { get; set; }
        public Item() { }
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
    }

    public class ItemValue                     // Однострочный-многострочный
    {
        public object Key { get; set; }                // онострочный значение null
        public List<Value> Values { get; set; }
        public ItemValue() { }
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
