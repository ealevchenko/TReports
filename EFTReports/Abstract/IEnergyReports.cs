using EFTReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Abstract
{
    public interface IEnergyReports
    {
        IQueryable<GroupEnergy> GroupEnergy { get; }
        IQueryable<GroupEnergy> GetGroupEnergy();
        GroupEnergy GetGroupEnergy(int id);
        int SaveGroupEnergy(GroupEnergy GroupEnergy);
        GroupEnergy DeleteGroupEnergy(int id);

        IQueryable<TypeEnergy> TypeEnergy { get; }
        IQueryable<TypeEnergy> GetTypeEnergy();
        TypeEnergy GetTypeEnergy(int id);
        int SaveTypeEnergy(TypeEnergy TypeEnergy);
        TypeEnergy DeleteTypeEnergy(int id);

        IQueryable<REnergyDay> REnergyDay { get; }
        IQueryable<REnergyDay> GetTREnergyDay();
        REnergyDay GetREnergyDay(int id);
        int SaveREnergyDay(REnergyDay REnergyDay);
        REnergyDay DeleteREnergyDay(int id);

    }
}
