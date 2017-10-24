using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLog
{

    public enum eventID : int
    {
       
        Null = -1,

        TData = 1000,
        TDataSources = 1100,

        EFBF9 = 2000,
        EFBF9_EFBF9UnloadMaterial = 2100,

        EFBF8 = 3000,
        EFBF8_EFBF9UnloadMaterial = 3100,

        EFBF7 = 4000,
        EFBF7_EFBF9UnloadMaterial = 4100,

        EFTReports = 10000,
        EFTReports_EFDataSet = 10100,
        EFTReports_EFEnergyReports = 10200,
        EFTReports_EFReportForms = 10300,
        EFTReports_EFDataSources = 10400,
        EFTReports_EFAccess = 10500,

        TR = 11000,
        TR_TREnergy = 11100,

        TRForm =  12000,
    }
}
