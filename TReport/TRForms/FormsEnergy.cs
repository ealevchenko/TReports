//using Measurement;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TReport.App_LocalResources;
//using TReport.TData;

//namespace TReport.TRForms
//{
//    interface IObject {
//        string Object { get; }
//    }
    
//    #region Класс формы представления FlowEnergyDay
//    public class FormEnergyFlowDay
//    {
//        public List<GroupEnergyFlowDay> Groups { get; set; }
//        public FormEnergyFlowDay() { }
//    }

//    public class GroupEnergyFlowDay :ObjectName
//    {
//        public int position { get; set; }
//        public List<TypeEnergyFlowDay> Types { get; set; }
//        public GroupEnergyFlowDay() { }
//    }

//    public class TypeEnergyFlowDay : ObjectName
//    {
//        public int position { get; set; }
//        public List<ItemEnergyFlowDay> Items { get; set; }
//        public TypeEnergyFlowDay() { }
//    }

//    public class ItemEnergyFlowDay : ObjectName, IObject
//    {
//        public int trobj { get; set; }
//        public int position { get; set; }
//        public ItemValue1 flow { get; set; }
//        public ItemValue1 avg_temp { get; set; }
//        public ItemValue1 avg_pressure { get; set; }
//        public ItemValue1 planimetric { get; set; }
//        public ItemValue1 pr_flow { get; set; }
//        public ItemValue1 time_norm { get; set; }
//        public ItemValue1 time_max { get; set; }
//        public ItemEnergyFlowDay() { }
//        public string Object
//        {
//            get { return ((trObj)this.trobj).ToString().GetResources(); }
//        }
//    }
//    #endregion

//    #region Класс формы представления EnergyDay
//    public class FormEnergyDay {
//        public List<GroupEnergyDay> Groups { get; set; }
//        public FormEnergyDay(){}
//    }

//    public class GroupEnergyDay : ObjectName
//    {
//        public int position { get; set; }
//        public List<TypeEnergyDay> Types { get; set; }
//        public GroupEnergyDay() { }
//    }

//    public class TypeEnergyDay : ObjectName
//    {
//        public int position { get; set; }
//        public List<ItemEnergyDay> Items { get; set; }
//        public TypeEnergyDay() { }
//    }

//    public class ItemEnergyDay : ObjectName
//    {
//        public int position { get; set; }
//        public List<ItemObject1> ItemObject { get; set; }
//        public ItemEnergyDay() { }
//    }

//    public class ItemObject1 : IObject
//    {
//        public int trobj { get; set; }
//        public ItemValue1 parameter { get; set; }
//        public ItemObject1() { }
//        public string Object
//        {
//            get { return ((trObj)this.trobj).ToString().GetResources(); }
//        }
//    }
//    #endregion

//    #region
//    public class ItemValue1
//    {
//        public int tag { get; set; }
//        public int? unit { get; set; }
//        public int? multiplier { get; set; }
//        public Object value { get; set; }
//        public ItemValue1() { }
//    }
//    /// <summary>
//    /// Класс наименование 
//    /// </summary>
//    public class ObjectName
//    {
//        public string name_ru { get; set; }
//        public string name_en { get; set; }
//        public string name_uk { get; set; }
//        public ObjectName() { }
//        public string name
//        {
//            get
//            {
//                switch (CultureInfo.CurrentUICulture.Name)
//                {
//                    case "en-US": return this.name_en;
//                    case "uk-UA": return this.name_uk;
//                    default: return this.name_ru;
//                }
//            }
//        }
//    }


//    #endregion

//}


