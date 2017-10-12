using EFTReports.Abstract;
using EFTReports.Entities;
using MessageLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libClass;

namespace EFTReports.Concrete
{
    public class EFReportForms: IReportForms
    {
        protected EFDbContext context = new EFDbContext();
        private eventID eventID = eventID.EFTReports_EFReportForms;


        public IQueryable<ReportForms> ReportForms
        {
            get { return context.ReportForms; }
        }

        public IQueryable<ReportForms> GetReportForms()
        {
            try
            {
                return ReportForms;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetReportForms()"), eventID);
                return null;
            }
        }

        public ReportForms GetReportForms(int id)
        {
            try
            {
                return GetReportForms().Where(r => r.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetReportForms(id={0})", id), eventID);
                return null;
            }
        }

        public ReportForms GetReportForms(string report)
        {
            try
            {
                return GetReportForms().Where(r => r.report.ToLower() == report.ToLower()).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetReportForms(report={0})", report), eventID);
                return null;
            }
        }

        public int SaveReportForms(ReportForms ReportForms)
        {
            ReportForms dbEntry;
            try
            {
                if (ReportForms.id == 0)
                {
                    dbEntry = new ReportForms()
                    {
                        id = 0,
                        report = ReportForms.report,
                        description = ReportForms.description,
                        xml_form = ReportForms.xml_form
                    };
                    context.ReportForms.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.ReportForms.Find(ReportForms.id);
                    if (dbEntry != null)
                    {
                        dbEntry.report = ReportForms.report;
                        dbEntry.description = ReportForms.description;
                        dbEntry.xml_form = ReportForms.xml_form;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveReportForms(ReportForms={0})", ReportForms.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public ReportForms DeleteReportForms(int id)
        {
            ReportForms dbEntry = context.ReportForms.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.ReportForms.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteReportForms(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
    }
}
