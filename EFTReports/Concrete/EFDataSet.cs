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
    public class EFDataSet : IDataSet, ITags
    {
        protected EFDbContext context = new EFDbContext();
        private eventID eventID = eventID.EFTReports_EFDataSet;

        #region TRDataSet
        public IQueryable<TRDataSet> DataSet
        {
            get { return context.TRDataSet; }
        }

        public IQueryable<TRDataSet> GetDataSet()
        {
            try
            {
                return DataSet;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetLogs()"),eventID);
                return null;
            }
        }

        public TRDataSet GetDataSet(int id)
        {
            try
            {
                return GetDataSet().Where(d => d.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetDataSet(id={0})", id), eventID);
                return null;
            }
        }

        public int SaveDataSet(TRDataSet DataSet)
        {
            TRDataSet dbEntry;
            try
            {
                if (DataSet.id == 0)
                {
                    dbEntry = new TRDataSet()
                    {
                        id = 0,
                        trobj = DataSet.trobj,
                        dataset1 = DataSet.dataset1,
                        description = DataSet.description,
                        script = DataSet.script,
                        TRTags = DataSet.TRTags

                    };
                    context.TRDataSet.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.TRDataSet.Find(DataSet.id);
                    if (dbEntry != null)
                    {
                        dbEntry.trobj = DataSet.trobj;
                        dbEntry.dataset1 = DataSet.dataset1;
                        dbEntry.description = DataSet.description;
                        dbEntry.script = DataSet.script;
                        dbEntry.TRTags = DataSet.TRTags;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveDataSet(DataSet={0})", DataSet.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public TRDataSet DeleteDataSet(int id)
        {
            TRDataSet dbEntry = context.TRDataSet.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.TRDataSet.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteDataSet(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
        #endregion

        #region TRTags
        public IQueryable<TRTags> TRTags
        {
            get { return context.TRTags; }
        }

        public IQueryable<TRTags> GetTRTags()
        {
            try
            {
                return TRTags;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetTRTags()"), eventID);
                return null;
            }
        }

        public TRTags GetTRTags(int id)
        {
            try
            {
                return GetTRTags().Where(d => d.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetTRTags(id={0})", id), eventID);
                return null;
            }
        }

        public int SaveTRTags(TRTags TRTags)
        {
            TRTags dbEntry;
            try
            {
                if (TRTags.id == 0)
                {
                    dbEntry = new TRTags()
                    {
                        id = 0,
                        id_dataset = TRTags.id_dataset, 
                        trobj = TRTags.trobj,
                        tag = TRTags.tag,
                        description = TRTags.description,
                        type_measurement = TRTags.type_measurement,
                        union = TRTags.union,
                        multiplier = TRTags.multiplier,

                    };
                    context.TRTags.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.TRTags.Find(TRTags.id);
                    if (dbEntry != null)
                    {
                        dbEntry.id_dataset = TRTags.id_dataset;
                        dbEntry.trobj = TRTags.trobj;
                        dbEntry.tag = TRTags.tag;
                        dbEntry.description = TRTags.description;
                        dbEntry.type_measurement = TRTags.type_measurement;
                        dbEntry.union = TRTags.union;
                        dbEntry.multiplier = TRTags.multiplier;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveTRTags(TRTags={0})", TRTags.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public TRTags DeleteTRTags(int id)
        {
            TRTags dbEntry = context.TRTags.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.TRTags.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteTRTags(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
        #endregion
    }
}
