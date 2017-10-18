using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Abstract
{
    interface IDataSets
    {
        IQueryable<DataSets> DataSets { get; }
        IQueryable<DataSets> GetDataSets();
        DataSets GetDataSets(int id);
        int SaveDataSets(DataSets DataSets);
        DataSets DeleteDataSets(int id);
    }
}
