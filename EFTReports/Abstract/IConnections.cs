using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Abstract
{
    interface IConnections
    {
        IQueryable<Connections> Connections { get; }
        IQueryable<Connections> GetConnections();
        Connections GetConnections(int id);
        int SaveConnections(Connections Connections);
        Connections DeleteConnections(int id);
    }
}
