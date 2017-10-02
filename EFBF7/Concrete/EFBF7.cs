using EFBF7.Abstract;
using EFBF7.DataSet;
using MessageLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBF7.Concrete
{
    public class EFBF7 : IBF7EnergySutki
    {
        protected EFDbContext context = new EFDbContext();
        protected string sp_bf7_ums;
        protected string sp_bf7_ub;
        protected string sp_bf7_es;

        private eventID eventID = eventID.EFBF7;

        public EFBF7() {
            try
            {
                sp_bf7_es = ConfigurationManager.AppSettings["sp_bf7_es"].ToString();
            }
            catch (Exception e)
            {
                e.WriteError("Ошибка чтения AppSettings",eventID);
            }
        }
        /// <summary>
        /// Получить энергоресурсяы за указанные сутки
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<bf7_EnergySutki> GetBF7EnergySutki(DateTime dt)
        {
            try
            {
                SqlParameter dt_start = new SqlParameter("@DT", dt);
                return context.Database.SqlQuery<bf7_EnergySutki>("EXEC " + this.sp_bf7_es + " @DT", dt_start).ToList();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF7EnergySutki(dt={0})", dt), eventID);
                return null;
            }
        }

    }
}
