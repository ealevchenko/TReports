using Measurement;
using MessageLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TReport.TData;
using TReport.TRForms;

namespace TReport.TREntities
{
    public class TREnergy:TR
    {
        private eventID eventID = eventID.TR_TREnergy;

        private Form formEnergyFlowDay;
        public Form EnergyFlowDay { get { return this.formEnergyFlowDay; } }
        private Form formEnergyDay;
        public Form EnergyDay { get { return this.formEnergyDay; } }

        public TREnergy(trObj trObj) : base(trObj) { GetForms(); }

        public TREnergy(trObj[] trObjs) : base(trObjs) {  GetForms(); }

        public TREnergy(List<trObj> trObjs) : base(trObjs) {  GetForms(); }

        public void GetForms() {

            this.formEnergyDay = base.forms.GetForm<Form>("EnergyDay");
            this.formEnergyFlowDay = base.forms.GetForm<Form>("EnergyFlowDay");
            //this.formEnergyDay = base.forms.GetFormOfFile<Form>(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TReports\TReport\XMLForms\NewFormEnergyDay.xml");             
            //this.formEnergyFlowDay = base.forms.GetFormOfFile<Form>(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TReports\TReport\XMLForms\NewFormEnergyFlowDay.xml");
        }

        public void GetEnergyFlowDay(DateTime date)
        {
            GetFormValue(date, this.formEnergyFlowDay);
        }

        public void GetEnergyDay(DateTime date) {
            GetFormValue(date, this.formEnergyDay);        
        }

    }
}
