using EFTReports.Abstract;
using EFTReports.Entities;
using MessageLog;
using libClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TReport;

namespace EFTReports.Concrete
{
    public enum type_dataset : int
    {
        TABLE=0, SP=1, VIEW=2,
    }

    public enum type_tag : int
    {
        DATETIME=1, INT=2, STRING=3, DATE=4
    }    

    public enum type_where : int
    {
        DATE=1, DATE_START=2, DATE_STOP=3, ID=4, ID_OBJECT=5, ID_REPORT
    }

    public class EFDataSources : IFactoryProviders, IConnections, IDataSets, IDataSetParameters, ITags
    {
        protected EFDbContext context = new EFDbContext();
        private eventID eventID = eventID.EFTReports_EFDataSources;

        #region FactoryProviders
        public IQueryable<FactoryProviders> FactoryProviders
        {
            get { return context.FactoryProviders; }
        }

        public IQueryable<FactoryProviders> GetFactoryProviders()
        {
            try
            {
                return FactoryProviders;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetFactoryProviders()"), eventID);
                return null;
            }
        }

        public FactoryProviders GetFactoryProviders(int id)
        {
            try
            {
                return GetFactoryProviders().Where(p => p.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetFactoryProviders(id={0})", id), eventID);
                return null;
            }
        }

        public int SaveFactoryProviders(FactoryProviders FactoryProviders)
        {
            FactoryProviders dbEntry;
            try
            {
                if (FactoryProviders.id == 0)
                {
                    dbEntry = new FactoryProviders()
                    {
                        id = 0,
                        provider = FactoryProviders.provider,
                        descriptipn = FactoryProviders.descriptipn
                    };
                    context.FactoryProviders.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.FactoryProviders.Find(FactoryProviders.id);
                    if (dbEntry != null)
                    {
                        dbEntry.provider = FactoryProviders.provider;
                        dbEntry.descriptipn = FactoryProviders.descriptipn;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveFactoryProviders(FactoryProviders={0})", FactoryProviders.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public FactoryProviders DeleteFactoryProviders(int id)
        {
            FactoryProviders dbEntry = context.FactoryProviders.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.FactoryProviders.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteFactoryProviders(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
        #endregion

        #region Connections
        public IQueryable<Connections> Connections
        {
            get { return context.Connections; }
        }

        public IQueryable<Connections> GetConnections()
        {
            try
            {
                return Connections;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetConnections()"), eventID);
                return null;
            }
        }

        public Connections GetConnections(int id)
        {
            try
            {
                return GetConnections().Where(c => c.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetConnections(id={0})", id), eventID);
                return null;
            }
        }

        public int SaveConnections(Connections Connections)
        {
            Connections dbEntry;
            try
            {
                if (Connections.id == 0)
                {
                    dbEntry = new Connections()
                    {
                        id = 0,
                        trobj = Connections.trobj,
                        id_provider = Connections.id_provider,
                        description = Connections.description,
                        connection = Connections.connection
                    };
                    context.Connections.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.Connections.Find(Connections.id);
                    if (dbEntry != null)
                    {
                        dbEntry.trobj = Connections.trobj;
                        dbEntry.id_provider = Connections.id_provider;
                        dbEntry.description = Connections.description;
                        dbEntry.connection = Connections.connection;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveConnections(Connections={0})", Connections.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public Connections DeleteConnections(int id)
        {
            Connections dbEntry = context.Connections.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.Connections.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteConnections(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
        #endregion

        #region DataSets
        public IQueryable<DataSets> DataSets
        {
            get { return context.DataSets; }
        }

        public IQueryable<DataSets> GetDataSets()
        {
            try
            {
                return DataSets;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetDataSets()"), eventID);
                return null;
            }
        }

        public DataSets GetDataSets(int id)
        {
            try
            {
                return GetDataSets().Where(c => c.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetDataSets(id={0})", id), eventID);
                return null;
            }
        }

        public int SaveDataSets(DataSets DataSets)
        {
            DataSets dbEntry;
            try
            {
                if (DataSets.id == 0)
                {
                    dbEntry = new DataSets()
                    {
                        id = 0,
                        trobj = DataSets.trobj,
                        id_connection = DataSets.id_connection,
                        type = DataSets.type,
                        description = DataSets.description,
                        linked = DataSets.linked,
                        dataset = DataSets.dataset
                    };
                    context.DataSets.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.DataSets.Find(DataSets.id);
                    if (dbEntry != null)
                    {
                        dbEntry.trobj = DataSets.trobj;
                        dbEntry.id_connection = DataSets.id_connection;
                        dbEntry.type = DataSets.type;
                        dbEntry.description = DataSets.description;
                        dbEntry.linked = DataSets.linked;
                        dbEntry.dataset = DataSets.dataset;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveDataSets(DataSets={0})", DataSets.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public DataSets DeleteDataSets(int id)
        {
            DataSets dbEntry = context.DataSets.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.DataSets.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteDataSets(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
        #endregion

        #region DataSetParameters
        public IQueryable<DataSetParameters> DataSetParameters
        {
            get { return context.DataSetParameters; }
        }

        public IQueryable<DataSetParameters> GetDataSetParameters()
        {
            try
            {
                return DataSetParameters;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetDataSetParameters()"), eventID);
                return null;
            }
        }

        public DataSetParameters GetDataSetParameters(int id)
        {
            try
            {
                return GetDataSetParameters().Where(c => c.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetDataSetParameters(id={0})", id), eventID);
                return null;
            }
        }

        public int SaveDataSetParameters(DataSetParameters DataSetParameters)
        {
            DataSetParameters dbEntry;
            try
            {
                if (DataSetParameters.id == 0)
                {
                    dbEntry = new DataSetParameters()
                    {
                        id = 0,
                        id_dataset = DataSetParameters.id_dataset,
                        description = DataSetParameters.description,
                        name = DataSetParameters.name,
                        type = DataSetParameters.type,
                        type_where = DataSetParameters.type_where
                    };
                    context.DataSetParameters.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.DataSetParameters.Find(DataSetParameters.id);
                    if (dbEntry != null)
                    {
                        dbEntry.id_dataset = DataSetParameters.id_dataset;
                        dbEntry.description = DataSetParameters.description;
                        dbEntry.name = DataSetParameters.name;
                        dbEntry.type = DataSetParameters.type;
                        dbEntry.type_where = DataSetParameters.type_where;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveDataSetParameters(DataSetParameters={0})", DataSetParameters.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public DataSetParameters DeleteDataSetParameters(int id)
        {
            DataSetParameters dbEntry = context.DataSetParameters.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.DataSetParameters.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteDataSetParameters(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
        #endregion

        #region Tags
        public IQueryable<Tags> Tags
        {
            get { return context.Tags; }
        }

        public IQueryable<Tags> GetTags()
        {
            try
            {
                return Tags;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetTags()"), eventID);
                return null;
            }
        }

        public Tags GetTags(int id)
        {
            try
            {
                return GetTags().Where(c => c.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetTags(id={0})", id), eventID);
                return null;
            }
        }

        public int SaveTags(Tags Tags)
        {
            Tags dbEntry;
            try
            {
                if (Tags.id == 0)
                {
                    dbEntry = new Tags()
                    {
                        id = 0,
                        id_dataset = Tags.id_dataset,
                        trobj = Tags.trobj,
                        tag = Tags.tag,
                        description = Tags.description,
                        type_measurement = Tags.type_measurement,
                        unit = Tags.unit,
                        multiplier = Tags.multiplier,

                    };
                    context.Tags.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.Tags.Find(Tags.id);
                    if (dbEntry != null)
                    {
                        dbEntry.id_dataset = Tags.id_dataset;
                        dbEntry.trobj = Tags.trobj;
                        dbEntry.tag = Tags.tag;
                        dbEntry.description = Tags.description;
                        dbEntry.type_measurement = Tags.type_measurement;
                        dbEntry.unit = Tags.unit;
                        dbEntry.multiplier = Tags.multiplier;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveTags(Tags={0})", Tags.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public Tags DeleteTags(int id)
        {
            Tags dbEntry = context.Tags.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.Tags.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteTags(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
        /// <summary>
        /// Получить набор данных Tags по указанному списку id тегов 
        /// </summary>
        /// <param name="list_id"></param>
        /// <returns></returns>
        public IQueryable<Tags> GetTags(int[] list_id)
        {
            string lists_id = null;
            try
            {
                lists_id = list_id.Count() > 0 ? list_id.IntsToString(',') : "0";
                string sql = "SELECT * FROM [treports].[Tags] where [id] in(" + lists_id + ") ";
                return context.Database.SqlQuery<Tags>(sql).AsQueryable();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetTags(list_id={0})", lists_id), eventID);
                return null;
            }

        }
        #endregion
    }
}
