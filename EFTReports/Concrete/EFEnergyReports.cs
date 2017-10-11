using EFTReports.Abstract;
using EFTReports.Entities;
using MessageLog;
using libClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Concrete
{
    public class EFEnergyReports : IEnergyReports
    {
        protected EFDbContext context = new EFDbContext();
        private eventID eventID = eventID.EFTReports_EFEnergyReports;

        #region GroupEnergy
        public IQueryable<GroupEnergy> GroupEnergy
        {
            get { return context.GroupEnergy; }
        }

        public IQueryable<GroupEnergy> GetGroupEnergy()
        {
            try
            {
                return GroupEnergy;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetGroupEnergy()"), eventID);
                return null;
            }
        }

        public GroupEnergy GetGroupEnergy(int id)
        {
            try
            {
                return GetGroupEnergy().Where(g => g.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetGroupEnergy(id={0})", id), eventID);
                return null;
            }
        }

        public int SaveGroupEnergy(GroupEnergy GroupEnergy)
        {
            GroupEnergy dbEntry;
            try
            {
                if (GroupEnergy.id == 0)
                {
                    dbEntry = new GroupEnergy()
                    {
                        id = 0,
                        group_energy_ru = GroupEnergy.group_energy_ru,
                        group_energy_en = GroupEnergy.group_energy_en,
                        TypeEnergy = GroupEnergy.TypeEnergy
                    };
                    context.GroupEnergy.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.GroupEnergy.Find(GroupEnergy.id);
                    if (dbEntry != null)
                    {
                        dbEntry.group_energy_ru = GroupEnergy.group_energy_ru;
                        dbEntry.group_energy_en = GroupEnergy.group_energy_en;
                        dbEntry.TypeEnergy = GroupEnergy.TypeEnergy;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveGroupEnergy(GroupEnergy={0})", GroupEnergy.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public GroupEnergy DeleteGroupEnergy(int id)
        {
            GroupEnergy dbEntry = context.GroupEnergy.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.GroupEnergy.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteGroupEnergy(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
        #endregion

        #region TypeEnergy
        public IQueryable<TypeEnergy> TypeEnergy
        {
            get { return context.TypeEnergy; }
        }

        public IQueryable<TypeEnergy> GetTypeEnergy()
        {
            try
            {
                return TypeEnergy;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetTypeEnergy()"), eventID);
                return null;
            }            
        }

        public TypeEnergy GetTypeEnergy(int id)
        {
            try
            {
                return GetTypeEnergy().Where(t => t.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetTypeEnergy(id={0})", id), eventID);
                return null;
            }
        }

        public IQueryable<TypeEnergy> GetTypeEnergyOfGroup(int group)
        {
            try
            {
                return GetTypeEnergy().Where(t => t.id_group == group);
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetTypeEnergyOfGroup(group={0})", group), eventID);
                return null;
            }
        }
        public int SaveTypeEnergy(TypeEnergy TypeEnergy)
        {
            TypeEnergy dbEntry;
            try
            {
                if (TypeEnergy.id == 0)
                {
                    dbEntry = new TypeEnergy()
                    {
                        id = 0,
                        id_group = TypeEnergy.id_group,
                        type_energy_ru = TypeEnergy.type_energy_ru,
                        type_energy_en = TypeEnergy.type_energy_en,

                    };
                    context.TypeEnergy.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.TypeEnergy.Find(TypeEnergy.id);
                    if (dbEntry != null)
                    {
                        dbEntry.id_group = TypeEnergy.id_group;
                        dbEntry.type_energy_ru = TypeEnergy.type_energy_ru;
                        dbEntry.type_energy_en = TypeEnergy.type_energy_en;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveTypeEnergy(TypeEnergy={0})", TypeEnergy.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public TypeEnergy DeleteTypeEnergy(int id)
        {
            TypeEnergy dbEntry = context.TypeEnergy.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.TypeEnergy.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteTypeEnergy(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
        #endregion

        //TODO: Убрать REnergyDay
        #region REnergyDay
        public IQueryable<REnergyDay> REnergyDay
        {
            get { return context.REnergyDay; }
        }

        public IQueryable<REnergyDay> GetTREnergyDay()
        {
            try
            {
                return REnergyDay;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetTREnergyDay()"), eventID);
                return null;
            }  
        }

        public REnergyDay GetREnergyDay(int id)
        {
            try
            {
                return GetTREnergyDay().Where(r => r.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetREnergyDay(id={0})", id), eventID);
                return null;
            }
        }

        public IQueryable<REnergyDay> GetREnergyDayOfType(int type)
        {
            try
            {
                return GetTREnergyDay().Where(r => r.id_type == type).OrderBy(r => r.position);
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetREnergyDayOfType(type={0})", type), eventID);
                return null;
            }
        }

        public int SaveREnergyDay(REnergyDay REnergyDay)
        {
            REnergyDay dbEntry;
            try
            {
                if (REnergyDay.id == 0)
                {
                    dbEntry = new REnergyDay()
                    {
                        id = 0,
                        id_type = REnergyDay.id_type,
                        trobj = REnergyDay.trobj,
                        name_energy_ru = REnergyDay.name_energy_ru,
                        name_energy_en = REnergyDay.name_energy_en,
                        position = REnergyDay.position,
                        flow = REnergyDay.flow,
                        avg_temp = REnergyDay.avg_temp,
                        avg_pressure = REnergyDay.avg_pressure,
                        planimetric = REnergyDay.planimetric,
                        pr_flow = REnergyDay.pr_flow,
                        time_norm = REnergyDay.time_norm,
                        time_max = REnergyDay.time_max
                    };
                    context.REnergyDay.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.REnergyDay.Find(REnergyDay.id);
                    if (dbEntry != null)
                    {
                        dbEntry.id_type = REnergyDay.id_type;
                        dbEntry.trobj = REnergyDay.trobj;
                        dbEntry.name_energy_ru = REnergyDay.name_energy_ru;
                        dbEntry.name_energy_en = REnergyDay.name_energy_en;
                        dbEntry.position = REnergyDay.position;
                        dbEntry.flow = REnergyDay.flow;
                        dbEntry.avg_temp = REnergyDay.avg_temp;
                        dbEntry.avg_pressure = REnergyDay.avg_pressure;
                        dbEntry.planimetric = REnergyDay.planimetric;
                        dbEntry.pr_flow = REnergyDay.pr_flow;
                        dbEntry.time_norm = REnergyDay.time_norm;
                        dbEntry.time_max = REnergyDay.time_max;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveREnergyDay(REnergyDay={0})", REnergyDay.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public REnergyDay DeleteREnergyDay(int id)
        {
            REnergyDay dbEntry = context.REnergyDay.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.REnergyDay.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteREnergyDay(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
        #endregion

        public IQueryable<ReportEnergyDay> GetReportEnergyDay()
        {
            try
            {
                string sql = "SELECT g.id AS [group], t.id AS type, e.id AS energy, e.trobj, e.name_energy_ru, e.name_energy_en, e.position, e.flow, e.avg_temp, e.avg_pressure, e.planimetric, e.pr_flow, e.time_norm, e.time_max "+
                                "FROM treports.GroupEnergy as g INNER JOIN treports.TypeEnergy as t ON g.id = t.id_group INNER JOIN treports.REnergyDay as e ON t.id = e.id_type";
                return context.Database.SqlQuery<ReportEnergyDay>(sql).AsQueryable();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetReportEnergyDay()"), eventID);
                return null;
            }  
        }

        #region report_flow_energy_day

        #region Group
        public IQueryable<ReportFlowEnergyDay_Group> ReportFlowEnergyDay_Group
        {
            get { return context.ReportFlowEnergyDay_Group; }
        }

        public IQueryable<ReportFlowEnergyDay_Group> GetReportFlowEnergyDay_Group()
        {
            try
            {
                return ReportFlowEnergyDay_Group;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetReportFlowEnergyDay_Group()"), eventID);
                return null;
            }
        }

        public ReportFlowEnergyDay_Group GetReportFlowEnergyDay_Group(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveReportFlowEnergyDay_Group(ReportFlowEnergyDay_Group ReportFlowEnergyDay_Group)
        {
            throw new NotImplementedException();
        }

        public ReportFlowEnergyDay_Group DeleteReportFlowEnergyDay_Group(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Type
        public IQueryable<ReportFlowEnergyDay_Type> ReportFlowEnergyDay_Type
        {
            get { return context.ReportFlowEnergyDay_Type; }
        }

        public IQueryable<ReportFlowEnergyDay_Type> GetReportFlowEnergyDay_Type()
        {
            try
            {
                return ReportFlowEnergyDay_Type;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetReportFlowEnergyDay_Type()"), eventID);
                return null;
            }
        }

        public ReportFlowEnergyDay_Type GetReportFlowEnergyDay_Type(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveReportFlowEnergyDay_Type(ReportFlowEnergyDay_Type ReportFlowEnergyDay_Type)
        {
            throw new NotImplementedException();
        }

        public ReportFlowEnergyDay_Type DeleteReportFlowEnergyDay_Type(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Item
        public IQueryable<ReportFlowEnergyDay_Item> ReportFlowEnergyDay_Item
        {
            get { return context.ReportFlowEnergyDay_Item; }
        }

        public IQueryable<ReportFlowEnergyDay_Item> GetReportFlowEnergyDay_Item()
        {
            try
            {
                return ReportFlowEnergyDay_Item;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetReportFlowEnergyDay_Item()"), eventID);
                return null;
            }
        }

        public ReportFlowEnergyDay_Item GetReportFlowEnergyDay_Item(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveReportFlowEnergyDay_Item(ReportFlowEnergyDay_Item ReportFlowEnergyDay_Item)
        {
            throw new NotImplementedException();
        }

        public ReportFlowEnergyDay_Item DeleteReportFlowEnergyDay_Item(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
