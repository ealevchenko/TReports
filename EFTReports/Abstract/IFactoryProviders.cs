using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Abstract
{
    interface IFactoryProviders
    {
        IQueryable<FactoryProviders> FactoryProviders { get; }
        IQueryable<FactoryProviders> GetFactoryProviders();
        FactoryProviders GetFactoryProviders(int id);
        int SaveFactoryProviders(FactoryProviders FactoryProviders);
        FactoryProviders DeleteFactoryProviders(int id);
    }
}
