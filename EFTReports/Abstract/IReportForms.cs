using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Abstract
{
    public interface IReportForms
    {
        IQueryable<ReportForms> ReportForms { get; }
        IQueryable<ReportForms> GetReportForms();
        ReportForms GetReportForms(int id);
        int SaveReportForms(ReportForms ReportForms);
        ReportForms DeleteReportForms(int id);
    }
}
