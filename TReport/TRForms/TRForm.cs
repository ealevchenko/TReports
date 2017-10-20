using EFTReports.Concrete;
using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;



namespace TReport.TRForms
{
    public class TRForm
    {

        public TRForm() { }

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
        /// <summary>
        /// Получить форму из базы
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetForm<T>()
        {
            EFReportForms rep_forms = new EFReportForms();
            ReportForms forms = rep_forms.GetReportForms(typeof(T).Name);
            if (forms == null) return default(T);
            return XMLStringToClass<T>(forms.xml_form);
        }
        /// <summary>
        /// Получить форму из файла
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <returns></returns>
        public T GetForm<T>(string file)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));            
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);   
            return  (T)((XmlSerializer)formatter).Deserialize(fs);  
        }
        /// <summary>
        /// Получить список тегов
        /// </summary>
        /// <param name="forms"></param>
        /// <param name="id_objs"></param>
        /// <returns></returns>
        public List<int> GetIDTags(object forms, int[] id_objs)
        {
            List<int> list = new List<int>();
            string xmlforms = ToXMLString(forms);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlforms);
            XmlNode root = doc.DocumentElement;
            XmlNodeList tags = root.SelectNodes(".//tag");
            EFDataSources efds = new EFDataSources();
            foreach (XmlNode tag in tags)
            {
                if (!String.IsNullOrWhiteSpace(tag.LastChild.InnerText)
                    && tag.LastChild.InnerText != "0")
                {
                    int id = int.Parse(tag.LastChild.InnerText);
                    Tags t = efds.GetTags(id);
                    if (t != null) {
                        int? obj = id_objs.ToList().Find(i => i == t.trobj);
                        if (obj > 0) { list.Add(t.id);}
                    }
                }
            }
            return list;
        }
    }
}
