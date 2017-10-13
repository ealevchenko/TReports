using EFTReports.Concrete;
using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace TReport.TREntities
{
    public class TRForms
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
        }
        public class ItemValue { 
            public int tag { get; set; }
            public int? unit { get; set; }
            public int? measurement { get; set; }
            public ItemValue() { }
        }

        #endregion

        public TRForms() { }

        /// <summary>
        /// Преобразовать объект в xml-сообщение
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string ToXMLString(object obj)
        {
            //try
            //{
            if (obj == null) return "Null";
            var xmlSerializer = new XmlSerializer(obj.GetType());
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, obj);
            return stringWriter.ToString();
            //}
            //catch (Exception ex)
            //{
            //    return "error ToXMLString";
            //}
        }
        /// <summary>
        /// Преобразовать xml-сообщение в object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public T XMLStringToClass<T>(string sourceString)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var stringReader = new StringReader(sourceString);
            return (T)xmlSerializer.Deserialize(stringReader);
        }

        public EnergyFlowDay GetFormEnergyFlowDay() {
            EFReportForms rep_forms = new EFReportForms();
            ReportForms forms = rep_forms.GetReportForms("FlowEnergyDay");
            if (forms == null) return null;
            return XMLStringToClass<EnergyFlowDay>(forms.xml_form);
        }

        public EnergyFlowDay GetFormEnergyFlowDay(string file) {
            XmlSerializer formatter = new XmlSerializer(typeof(EnergyFlowDay));
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            EnergyFlowDay res = (EnergyFlowDay)((XmlSerializer)formatter).Deserialize(fs);
            return  res;
        }

    }
}
