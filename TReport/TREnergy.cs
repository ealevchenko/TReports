using EFBF9.DataSet;
using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport
{
    
    public class TREnergy:TR
    {
        protected List<TREnergoSutki> list = new List<TREnergoSutki>();
        
        public TREnergy(trObj trObj) :base(trObj) { }
        
        public class TREnergoSutki
        {
            public trObj trObj { get; set; }
            public DateTime datetime { get; set; }
            public EnergyValueEntity natural_gas_bf { get; set; }
            //public EnergyValueEntity natural_gas_hpp { get; set; }
            //public EnergyValueEntity natural_gas_technical_needs { get; set; }
        }

        public class BF9_TREnergoSutki : DataMeasurement<TREnergoSutki>
        {
            public BF9_TREnergoSutki(EnergoSutki obj)
                : base(obj)
            {

            }

            public BF9_TREnergoSutki(List<EnergoSutki> list_obj)
                : base(list_obj)
            {

            }

            public override TREnergoSutki Convert(object obj)
            {
                try
                {
                    return new TREnergoSutki()
                    {
                        trObj = TReport.trObj.dc2_dp9,
                        datetime = ((EnergoSutki)obj).Date,
                        natural_gas_bf = new EnergyValueEntity()
                        {
                            name = "Природный газ на ДП9",
                            flow = new FlowValue((double)((EnergoSutki)obj).DP_FPG24, "Расход за сутки", uFlow.m3_hour, Multiplier.thousand),
                            avg_temp = new TempValue((double)((EnergoSutki)obj).PrGazPech_T, "Средняя температура", uTemp.grad_C, Multiplier.No),
                            avg_pressure = new PressureValue((double)((EnergoSutki)obj).PrGazPech_P, "Средне давление", uPressure.kgs_sm2, Multiplier.No),
                            planimetric = new PlanimetricValue((double)((EnergoSutki)obj).PrGazPech_a, "Планиметрическое число", uPlanimetric.Np, Multiplier.No),
                            pr_flow = new FlowValue((((EnergoSutki)obj).Pr_Gaz_naPech != null ? (double)((EnergoSutki)obj).Pr_Gaz_naPech: 0.0), "Приведенный расход за сутки", uFlow.m3_hour, Multiplier.thousand),
                            time_norm = new TimeValue((double)((EnergoSutki)obj).PG_TimeN, "Время подачи, норма", uTime.min, Multiplier.No),
                            time_max = new TimeValue((double)((EnergoSutki)obj).PG_TimeM, "Время подачи, макс", uTime.min, Multiplier.No),
                        },
                        //natural_gas_hpp = new EnergyValueEntity()
                        //{
                        //    name = "Природный газ на ТЭЦ-3",
                        //    flow = new FlowValue((double)((EnergoSutki)obj).DP_FGTets3sut, "Расход за сутки", uFlow.m3_hour, Multiplier.thousand),
                        //    planimetric = new PlanimetricValue((double)((EnergoSutki)obj).DP_PCHPGT3, "Планиметрическое число", uPlanimetric.Np, Multiplier.No),
                        //},
                        //natural_gas_technical_needs = new EnergyValueEntity()
                        //{
                        //    name = "Природный газ на технужды ДП9",
                        //    flow = new FlowValue((double)((EnergoSutki)obj).DP_FPGND24, "Расход за сутки", uFlow.m3_hour, Multiplier.thousand),
                        //}

                    };
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public void GetEnergoSutki(DateTime date){
            foreach (trObj obj in Enum.GetValues(typeof(trObj)))
            {
                switch (obj) {
                    case TReport.trObj.dc2_dp9:
                        EFBF9.Concrete.EFBF9 efdp9 = new EFBF9.Concrete.EFBF9();
                        List<EnergoSutki> list = efdp9.GetBF9EnergoSutki(DateTime.Now.AddDays(-1));
                        if (list != null && list.Count > 0) {
                            this.list.Add(new BF9_TREnergoSutki(list[0]).ListData[0]);
                        }
                        break;

                
                }
            }
        }
    }
}
