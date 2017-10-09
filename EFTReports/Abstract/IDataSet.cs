using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Abstract
{
    public interface IDataSet
    {
        IQueryable<TRDataSet> DataSet { get; }
        IQueryable<TRDataSet> GetDataSet();
        TRDataSet GetDataSet(int id);
        int SaveDataSet(TRDataSet DataSet);
        TRDataSet DeleteDataSet(int id);
    }
}
