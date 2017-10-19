using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Abstract
{
    public interface IAccess
    {
        IQueryable<Access> Access { get; }
        IQueryable<Access> GetAccess();
        Access GetAccess(int id);
        Access GetAccess(string controller, string action);
        int SaveAccess(Access Access);
        Access DeleteAccess(int id);
    }
}
