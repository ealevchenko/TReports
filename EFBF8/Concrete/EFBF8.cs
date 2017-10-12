using EFBF8.Abstract;
using EFBF8.DataSet;
using MessageLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBF8.Concrete
{
    public class EFBF8 : IBF8EnergySutki
    {
        protected EFDbContext context = new EFDbContext();
        protected string sp_bf8_ums;
        protected string sp_bf8_ub;
        protected string sp_bf8_es;

        private eventID eventID = eventID.EFBF8;

        public EFBF8() {
            try
            {
                sp_bf8_es = ConfigurationManager.AppSettings["sp_bf8_es"].ToString();
            }
            catch (Exception e)
            {
                e.WriteError("Ошибка чтения AppSettings",eventID);
            }
        }
        public List<bf8_EnergySutki> GetBF8EnergySutki(DateTime dt, string sp)
        {
            try
            {
                SqlParameter dt_start = new SqlParameter("@DT", dt);
                return context.Database.SqlQuery<bf8_EnergySutki>("EXEC " + sp + " @DT", dt_start).ToList();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF8EnergySutki(dt={0})", dt), eventID);
                return null;
            }
        }
        /// <summary>
        /// Получить энергоресурсяы за указанные сутки
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<bf8_EnergySutki> GetBF8EnergySutki(DateTime dt)
        {
            try
            {
                SqlParameter dt_start = new SqlParameter("@DT", dt);
                return context.Database.SqlQuery<bf8_EnergySutki>("EXEC " + this.sp_bf8_es + " @DT", dt_start).ToList();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF8EnergySutki(dt={0})", dt), eventID);
                return null;
            }
        }

    }
}
