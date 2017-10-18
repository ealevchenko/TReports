using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Abstract
{
    interface ITags
    {
        IQueryable<Tags> Tags { get; }
        IQueryable<Tags> GetTags();
        Tags GetTags(int id);
        int SaveTags(Tags Tags);
        Tags DeleteTags(int id);

        IQueryable<Tags> GetTags(int[] list_id);
    }
}
