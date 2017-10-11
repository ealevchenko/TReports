using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Abstract
{
    public interface IReportFlowEnergyDay
    {
        IQueryable<ReportFlowEnergyDay_Group> ReportFlowEnergyDay_Group { get; }
        IQueryable<ReportFlowEnergyDay_Group> GetReportFlowEnergyDay_Group();
        ReportFlowEnergyDay_Group GetReportFlowEnergyDay_Group(int id);
        int SaveReportFlowEnergyDay_Group(ReportFlowEnergyDay_Group ReportFlowEnergyDay_Group);
        ReportFlowEnergyDay_Group DeleteReportFlowEnergyDay_Group(int id);

        IQueryable<ReportFlowEnergyDay_Type> ReportFlowEnergyDay_Type { get; }
        IQueryable<ReportFlowEnergyDay_Type> GetReportFlowEnergyDay_Type();
        ReportFlowEnergyDay_Type GetReportFlowEnergyDay_Type(int id);
        int SaveReportFlowEnergyDay_Type(ReportFlowEnergyDay_Type ReportFlowEnergyDay_Type);
        ReportFlowEnergyDay_Type DeleteReportFlowEnergyDay_Type(int id);

        IQueryable<ReportFlowEnergyDay_Item> ReportFlowEnergyDay_Item { get; }
        IQueryable<ReportFlowEnergyDay_Item> GetReportFlowEnergyDay_Item();
        ReportFlowEnergyDay_Item GetReportFlowEnergyDay_Item(int id);
        int SaveReportFlowEnergyDay_Item(ReportFlowEnergyDay_Item ReportFlowEnergyDay_Item);
        ReportFlowEnergyDay_Item DeleteReportFlowEnergyDay_Item(int id);



    }
}
