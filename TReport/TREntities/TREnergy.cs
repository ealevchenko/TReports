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
        public enum Report : int
        {
            EnergyFlowDay = 0, EnergyAVGDay = 1, EnergyGranulDay = 2,
        }

        private List<Form> list_forms = new List<Form>();
        public List<Form> ReportForms { get { return this.list_forms; } }
        private eventID eventID = eventID.TR_TREnergy;

        private List<Report> reports = new List<Report>();

        public TREnergy(trObj trObj, Report[] reports) : base(trObj) { this.reports = reports.ToList(); GetForms(); }

        public TREnergy(trObj[] trObjs, Report[] reports) : base(trObjs) { this.reports = reports.ToList(); GetForms(); }

        public TREnergy(List<trObj> trObjs, Report[] reports) : base(trObjs) { this.reports = reports.ToList(); GetForms(); }

        public void GetForms()
        {
            try
            {
                foreach (Report rep in reports)
                {
                    Form fm = base.forms.GetForm<Form>(rep.ToString());
                    //Form fm = base.forms.GetFormOfFile<Form>(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TReports\TReport\XMLForms\EnergyAVGDay.xml");
                    //Form fm = base.forms.GetFormOfFile<Form>(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TReports\TReport\XMLForms\EnergyGranulDay.xml");
                    //Form fm = base.forms.GetFormOfFile<Form>(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TReports\TReport\XMLForms\NewFormEnergyFlowDay.xml");
                    if (fm != null) { this.list_forms.Add(fm); }
                }
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetForms()"), eventID);
            }
        }

        public void GetReports(DateTime date)
        {
            try
            {
                foreach (Report rep in this.reports)
                {
                    Form fm = this.list_forms.Find(f => f.name.ToLower() == rep.ToString().ToLower());
                    if (fm != null)
                    {
                        GetFormValue(date, fm);
                    }
                }
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetReports(date={0})", date), eventID);
            }
        }
    }
}
