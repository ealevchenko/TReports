using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport.TData
{
    public class TRDBFactory
    {
        protected DataSet db_result = new DataSet();

        public TRDBFactory() { }

        //protected DataTable Select(string sql, FactoryConnection fc, string TableName)
        //{
        //    DbProviderFactory provider = DbProviderFactories.GetFactory(fc.Provider);
        //    DbConnection con = provider.CreateConnection();
        //    con.ConnectionString = fc.ConnectionString;
        //    DbCommand cmd = provider.CreateCommand();
        //    cmd.CommandText = sql;
        //    cmd.Connection = con;

        //    DbDataAdapter da = provider.CreateDataAdapter();
        //    da.SelectCommand = cmd;
        //    try
        //    {
        //        da.Fill(this.db_result, TableName.ToString());
        //    }
        //    catch (Exception err)
        //    {

        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return this.db_result.Tables[TableName.ToString()];
        //}
        ///// <summary>
        ///// Выполнить запрос
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="fc"></param>
        ///// <returns></returns>
        //protected DataTable Select(String sql, FactoryConnection fc)
        //{

        //    return Select(sql, fc, "Table");
        //}
        ///// <summary>
        ///// Выполнить командный запрос
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="fc"></param>
        ///// <returns></returns>
        //protected int Update(String sql, FactoryConnection fc)
        //{
        //    int res;
        //    DbProviderFactory provider = DbProviderFactories.GetFactory(fc.Provider);
        //    DbConnection con = provider.CreateConnection();
        //    con.ConnectionString = fc.ConnectionString;
        //    DbCommand cmd = provider.CreateCommand();
        //    cmd.CommandText = sql;
        //    cmd.Connection = con;
        //    try
        //    {
        //        con.Open();
        //        res = cmd.ExecuteNonQuery();

        //    }
        //    catch (Exception err)
        //    {

        //        return -1;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return res;
        //}
    }
}
