using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Abstract
{
    interface IDataSetParameters
    {
        IQueryable<DataSetParameters> DataSetParameters { get; }
        IQueryable<DataSetParameters> GetDataSetParameters();
        DataSetParameters GetDataSetParameters(int id);
        int SaveDataSetParameters(DataSetParameters DataSetParameters);
        DataSetParameters DeleteDataSetParameters(int id);
    }
}
