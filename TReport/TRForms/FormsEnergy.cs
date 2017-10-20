using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport.TRForms
{
    #region Класс формы представления FlowEnergyDay
    public class EnergyFlowDay
    {
        public List<GroupEnergyFlowDay> Groups { get; set; }
        public EnergyFlowDay() { }
    }

    public class GroupEnergyFlowDay
    {
        public int id_group { get; set; }
        public int position { get; set; }
        public List<TypeEnergyFlowDay> Types { get; set; }
        public GroupEnergyFlowDay() { }
    }

    public class TypeEnergyFlowDay
    {
        public int id_type { get; set; }
        public int position { get; set; }
        public List<ItemEnergyFlowDay> Items { get; set; }
        public TypeEnergyFlowDay() { }
    }

    public class ItemEnergyFlowDay
    {
        public int trobj { get; set; }
        public string name_energy_ru { get; set; }
        public string name_energy_en { get; set; }
        public int position { get; set; }
        public ItemValue flow { get; set; }
        public ItemValue avg_temp { get; set; }
        public ItemValue avg_pressure { get; set; }
        public ItemValue planimetric { get; set; }
        public ItemValue pr_flow { get; set; }
        public ItemValue time_norm { get; set; }
        public ItemValue time_max { get; set; }
        public ItemEnergyFlowDay() { }
        public string name_energy
        {
            get
            {
                if (CultureInfo.CurrentUICulture.Name == "en-US")
                { return this.name_energy_en; }
                else { return this.name_energy_ru; }
            }
        }
    }
    #endregion

    #region Класс формы представления EnergyDay
    public class FormEnergyDay {
        public List<GroupEnergyDay> Groups { get; set; }
        public FormEnergyDay(){}
    }

    public class GroupEnergyDay : ObjectName
    {
        public int position { get; set; }
        public List<TypeEnergyDay> Types { get; set; }
        public GroupEnergyDay() { }
    }

    public class TypeEnergyDay : ObjectName
    {
        public int position { get; set; }
        public List<ItemEnergyDay> Items { get; set; }
        public TypeEnergyDay() { }
    }

    public class ItemEnergyDay : ObjectName
    {
        public int position { get; set; }
        public List<ItemObject> ItemObject { get; set; }
        public ItemEnergyDay() { }
    }

    public class ItemObject
    {
        public int trobj { get; set; }
        public ItemValue parameter { get; set; }
        public ItemObject() { }
    }
    #endregion

    #region
    public class ItemValue
    {
        public int tag { get; set; }
        public int? unit { get; set; }
        public int? multiplier { get; set; }
        public Object value { get; set; }
        public ItemValue() { }
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


    #endregion
}
