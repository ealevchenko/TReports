using EFBF9.DataSet;
using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        public class DM_BF9_UnloadBunker
        {
            public DateTime datetime { get; set; }
            public PressureValue davl1 { get; set; }
        }

        public class BF9_UnloadBunkerDataMeasurement : DataMeasurement<DM_BF9_UnloadBunker>
        {
            public BF9_UnloadBunkerDataMeasurement(UnloadBunker obj)
                : base(obj)
            {

            }

            public BF9_UnloadBunkerDataMeasurement(List<UnloadBunker> list_obj)
                : base(list_obj)
            {

            }

            public override DM_BF9_UnloadBunker Convert(object obj)
            {
                return new DM_BF9_UnloadBunker()
                {
                    datetime = ((UnloadBunker)obj).Дата_и_время,
                    davl1 = new PressureValue((double)((UnloadBunker)obj).Точность_рассыпания, "Точность_рассыпания", uPressure.bar, Multiplier.No)
                };
            }
        }
        
        static void Main(string[] args)
        {
            //PressureUnit pu = new PressureUnit("Тест параметр давление", uPressure.kgs_m2, Multiplier.No);
            //FlowUnit fu = new FlowUnit("Тест параметр расход", uFlow.kg_hour, Multiplier.No);

            //List<UnitMeasurement> list = new List<UnitMeasurement>();
            //list.Add(pu);
            //list.Add(fu);

            //foreach (UnitMeasurement um in list)
            //{
            //    Console.WriteLine("Элемент {0}, класс {1}", um.Description, um.GetType());
            //}

            //PressureValue pv = new PressureValue(4.5, "Тест параметр давление", uPressure.kgs_m2, Multiplier.No);
            //FlowValue fv = new FlowValue(1.1, "Тест параметр расход", uFlow.g_hour, Multiplier.No);

            //List<ValueMeasurement> vlist = new List<ValueMeasurement>();
            //vlist.Add(pv);
            //vlist.Add(fv);

            //foreach (ValueMeasurement um in vlist)
            //{
            //    Console.WriteLine("Элемент {0}, класс {1}, значение {2}, тип {3}", um.Description, um.GetType(), um.Value, um.TypeValue);
            //}

            EFBF9.Concrete.EFBF9 efdp9 = new EFBF9.Concrete.EFBF9();
            List<UnloadBunker> list = new List<UnloadBunker>();
            list = efdp9.GetBF9UnloadBunker(DateTime.Now.AddHours(-5), DateTime.Now);
            BF9_UnloadBunkerDataMeasurement ubdm = new BF9_UnloadBunkerDataMeasurement(list);
            BF9_UnloadBunkerDataMeasurement ubdm1 = new BF9_UnloadBunkerDataMeasurement(list[1]);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
