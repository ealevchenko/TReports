using EFTReports.Concrete;
using EFTReports.Entities;
using Measurement;
using MessageLog;
using libClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TReport.TData
{
    public enum type_dataset : int
    {
        TABLE = 0, SP = 1, VIEW = 2,
    }

    public enum type_tag : int
    {
        DATETIME = 1, INT = 2, STRING = 3, DATE = 4
    }

    public enum type_where : int
    {
        DATE = 1, DATE_START = 2, DATE_STOP = 3, ID = 4, ID_OBJECT = 5, ID_REPORT
    }
    
    public class DataMeasurement
    {
        public int id { get; set; }
        public int id_dataset { get; set; }
        public DBValueMeasurement value_measurement { get; set; }
    }

    public class SQLParameter
    {
        public type_where where { get; set; }
        public object value { get; set; }
        public SQLParameter()
        {}
    }    

    public class Parameter
    {
        public string name { get; set; }
        public DbType type { get; set; }
        //public type_where where { get; set; }
        public object value { get; set; }
        public Parameter(DataSetParameters dsp, object value)
        {
            this.name = dsp.name.Trim();
            switch ((type_tag)dsp.type)
            {
                case type_tag.DATETIME: this.type = DbType.DateTime; break;
                case type_tag.INT: this.type = DbType.Int32; break;
                case type_tag.STRING: this.type = DbType.String; break;
                case type_tag.DATE: this.type = DbType.Date; break;
                default: this.type = DbType.Object; break;
            }
            //this.where = where;
            this.value = value;
        }
    }

    public class DataSources
    {
        public trObj trobj { get; set; }
        public string provider { get; set; }
        public string connection { get; set; }
        public type_dataset type { get; set; }
        public string linked { get; set; }
        public string dataset { get; set; }
        public Parameter[] parameters { get; set; }
        public DataSources() { }
    }

    public class TDataSources
    {
        private eventID eventID = eventID.TDataSources;

        public TDataSources(){}

        /// <summary>
        /// Получить DataSources по указаному dataset c определенной выборкой
        /// </summary>
        /// <param name="id_dataset"></param>
        /// <param name="sqlparams"></param>
        /// <returns></returns>
        public DataSources GetDataSources(int id_dataset, SQLParameter[] sqlparams)
        {
            try
            {
                EFDataSources efds = new EFDataSources();
                DataSets ds = efds.GetDataSets(id_dataset);
                if (ds == null) return null;
                List<Parameter> list = new List<Parameter>();
                foreach (DataSetParameters dsp in ds.DataSetParameters)
                {
                    foreach (SQLParameter sqlp in sqlparams)
                    {
                        if (dsp.type_where.Contains(sqlp.where.ToString()))
                        {
                            // Добавим и выходим
                            list.Add(new Parameter(dsp, sqlp.value));
                            break;
                        }
                    }
                }
                Connections conn = efds.GetConnections(ds.id_connection);
                if (conn == null) return null;
                FactoryProviders provider = efds.GetFactoryProviders(conn.id_provider);
                if (provider == null) return null;
                DataSources sources = new DataSources()
                {
                    trobj = (trObj)ds.trobj,
                    provider = provider.provider,
                    connection = conn.connection,
                    type = (type_dataset)ds.type,
                    linked = ds.linked,
                    dataset = ds.dataset,
                    parameters = list.ToArray()
                };
                return sources;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetConnections(id_dataset={0}, type_where={1})", id_dataset, sqlparams), eventID);
                return null;
            }
        }
        /// <summary>
        /// получить данные DataTable выполнив хранимую процедуру
        /// </summary>
        /// <param name="date"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public DataTable GetSP(DataSources ds) {
            if (ds == null) return null;
            DataSet dataset = new DataSet();
            //Создаем фабрику подключения
            DbProviderFactory provider = DbProviderFactories.GetFactory(ds.provider);
            DbConnection con = provider.CreateConnection();
            con.ConnectionString = ds.connection;
            DbCommand cmd = provider.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ds.dataset;
            cmd.Connection = con;
            foreach (Parameter p in ds.parameters) { 
                DbParameter dbp = provider.CreateParameter();
                dbp.ParameterName = p.name;
                dbp.DbType = p.type;
                //dbp.Value = date;
                dbp.Value = p.value;
                cmd.Parameters.Add(dbp);
            }

            DbDataAdapter da = provider.CreateDataAdapter();
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dataset, "Result");
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetSP(ds={0})", ds.GetFieldsAndValue()), eventID);
            }
            finally
            {
                con.Close();
            }
            return dataset.Tables["Result"];
        }

        public DataTable GetDataTable(DataSources ds) {
            switch (ds.type) {
                case type_dataset.SP: return GetSP(ds);
                //case type_dataset.TABLE:
                //case type_dataset.VIEW:
                default: return null;
            }
        }
        /// <summary>
        /// Получить список тегов в формате DataMeasurement
        /// </summary>
        /// <param name="list_id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<DataMeasurement> GetDataMeasurement(List<int> list_id, SQLParameter[] sqlparams)
        {
            List<DataMeasurement> list = new List<DataMeasurement>();
            EFDataSources efds = new EFDataSources();

            List<Tags> list_tags = efds.GetTags(list_id.ToArray()).ToList();

            List<IGrouping<int, Tags>> result = list_tags.GroupBy(t => t.id_dataset).ToList();
            foreach (IGrouping<int, Tags> ds in result)
            {
                DataSources dsc = GetDataSources(ds.Key, sqlparams);
                if (dsc == null) return null;
                DataTable data = GetDataTable(dsc);
                foreach (Tags tag in ds){

                    try
                    {
                        object val =null;
                        if (data != null && data.Rows.Count > 0) {
                            val = tag.tag.GetExpression(data.Rows[0]);
                        }
                        list.Add(new DataMeasurement()
                        {
                            id = tag.id,
                            id_dataset = tag.id_dataset,
                            value_measurement = ((TypeMeasurement)tag.type_measurement).GetDBValueMeasurement(val, tag.tag.Trim(), "", tag.unit, (Multiplier)tag.multiplier)
                        });
                    }
                    catch (Exception e)
                    {
                        e.WriteError(String.Format("Ошибка преобразования тега: id={0}, tag={1} ", tag.id, tag.tag), eventID);
                    }
                }
            }
            return list;
        }
    }
}
