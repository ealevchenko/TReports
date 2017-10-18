using EFBF7.DataSet;
using EFBF8.DataSet;
using EFBF9.DataSet;
using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TReport;
using libClass;

namespace Testing
{
    class Program
    {






        public static void Main(string[] args)
        {

            #region Test_EFBF7
            Test_EFBF7 tefbf7 = new Test_EFBF7();
            //tefbf7.GetBF7EnergySutkit(); // Получить энерго ресурсы за уазаную дату
            #endregion

            #region Test_EFBF8
            Test_EFBF8 tefbf8 = new Test_EFBF8();
            //tefbf8.GetBF8EnergySutkit(); // Получить энерго ресурсы за уазаную дату
            #endregion

            #region Test_EFBF9
            Test_EFBF9 tefbf9 = new Test_EFBF9();
            //tefbf9.GetBF9EnergySutkit(); // Получить энерго ресурсы за уазаную дату
            #endregion

            #region Test_TREnergy
            Test_TREnergy ttre = new Test_TREnergy();
            //ttre.GetEnergySutkit(); // Получить энерго ресурсы за уазаную дату по всем печам
            //ttre.GetResources(); // тест ресурсов
            ttre.GetEnergyFlowDay(); // тест ресурсов за сутки
            #endregion

            #region Test_EFDataSet
            Test_EFDataSet tds = new Test_EFDataSet();
            //tds.EFDataSet_TRDataSet(); //Проверка работы dataset
            //tds.EFDataSet_TRTags(); //Проверка работы tags
            #endregion

            //#region Test_TData Old
            //Test_TData ttd = new Test_TData();
            ////ttd.GetDataMeasurement(); // Old Проверка получения данных по id
            //#endregion

            #region Test_TDataSources
            Test_TDataSources ttds = new Test_TDataSources();
            //ttds.GetDataMeasurement(); // Проверка получения данных по id
            #endregion

            #region TestXML
            TestXML xml = new TestXML();
            //xml.getXML();
            #endregion
            //PressureUnit pu = new PressureUnit("Тест параметр давление", uPressure.kgs_m2, Multiplier.nott);
            //FlowUnit fu = new FlowUnit("Тест параметр расход", uFlow.kg_hour, Multiplier.not);

            //List<UnitMeasurement> list = new List<UnitMeasurement>();
            //list.Add(pu);
            //list.Add(fu);

            //foreach (UnitMeasurement um in list)
            //{
            //    Console.WriteLine("Элемент {0}, класс {1}", um.Description, um.GetType());
            //}

            //PressureValue pv = new PressureValue(4.5, "Тест параметр давление", uPressure.kgs_m2, Multiplier.not);
            //FlowValue fv = new FlowValue(1.1, "Тест параметр расход", uFlow.g_hour, Multiplier.not);

            //List<ValueMeasurement> vlist = new List<ValueMeasurement>();
            //vlist.Add(pv);
            //vlist.Add(fv);

            //foreach (ValueMeasurement um in vlist)
            //{
            //    Console.WriteLine("Элемент {0}, класс {1}, значение {2}, тип {3}", um.Description, um.GetType(), um.Value, um.TypeValue);
            //}

            //EFBF9.Concrete.EFBF9 efdp9 = new EFBF9.Concrete.EFBF9();
            //List<UnloadBunker> list = new List<UnloadBunker>();
            //list = efdp9.GetBF9UnloadBunker(DateTime.Now.AddHours(-5), DateTime.Now);
            //BF9_UnloadBunkerDataMeasurement ubdm = new BF9_UnloadBunkerDataMeasurement(list);
            //BF9_UnloadBunkerDataMeasurement ubdm1 = new BF9_UnloadBunkerDataMeasurement(list[1]);



            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
