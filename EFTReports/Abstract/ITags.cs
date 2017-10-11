using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Abstract
{
    public interface ITags
    {
        IQueryable<TRTags> TRTags { get; }
        IQueryable<TRTags> GetTRTags();
        TRTags GetTRTags(int id);
        int SaveTRTags(TRTags Tags);
        TRTags DeleteTRTags(int id);

        IQueryable<TRTags> GetTRTags(int[] list_id);
    }
}
