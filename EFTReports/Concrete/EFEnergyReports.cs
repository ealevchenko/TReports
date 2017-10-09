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


                    };
                    context.GroupEnergy.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.GroupEnergy.Find(GroupEnergy.id);
                    if (dbEntry != null)
                    {
                        //dbEntry
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


                    };
                    context.TypeEnergy.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.TypeEnergy.Find(TypeEnergy.id);
                    if (dbEntry != null)
                    {
                        //dbEntry
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


                    };
                    context.REnergyDay.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.REnergyDay.Find(REnergyDay.id);
                    if (dbEntry != null)
                    {
                        //dbEntry
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
    }
}
