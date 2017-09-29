using EFBF9.Abstract;
using EFBF9.DataSet;
using MessageLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBF9.Concrete
{
    public class EFBF9 : IBF9UnloadMaterial, IBF9UnloadBunker
    {
        protected EFDbContext context = new EFDbContext();
        protected string sp_bf9_ums;
        protected string sp_bf9_ub;
        protected string sp_bf9_es;

        private eventID eventID = eventID.EFBF9;

        public EFBF9() {
            try
            {
                sp_bf9_ums = ConfigurationManager.AppSettings["sp_bf9_ums"].ToString();
                sp_bf9_ub = ConfigurationManager.AppSettings["sp_bf9_ub"].ToString();
                sp_bf9_es = ConfigurationManager.AppSettings["sp_bf9_es"].ToString();
            }
            catch (Exception e)
            {
                e.WriteError("Ошибка чтения AppSettings",eventID);
            }
        }
        /// <summary>
        /// Получить выгрузку материалов посменно начиная с указанной даты
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<UnloadMaterialSmena> GetBF9UnloadMaterialSmena(DateTime dt)
        {
            try
            {
                SqlParameter dt_start = new SqlParameter("@Date", dt);
                return context.Database.SqlQuery<UnloadMaterialSmena>("EXEC " + this.sp_bf9_ums + " @Date", dt_start).ToList();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF9UnloadMaterialSmena(dt={0})", dt), eventID);
                return null;
            }
        }
        /// <summary>
        /// Получить протокол загрузки БЗУ за указанный период
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public List<UnloadBunker> GetBF9UnloadBunker(DateTime start, DateTime stop)
        {
            try
            {
                SqlParameter dt_start = new SqlParameter("@DTB", start);
                SqlParameter dt_stop = new SqlParameter("@DTE", stop);
                return context.Database.SqlQuery<UnloadBunker>("EXEC " + this.sp_bf9_ub + " @DTB, @DTE", dt_start, dt_stop).ToList();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF9UnloadBunker(start={0}, stop={1})", start, stop), eventID);
                return null;
            }
        }
        /// <summary>
        /// Получить энергоресурсяы за указанные сутки
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<bf9_EnergySutki> GetBF9EnergoSutki(DateTime dt)
        {
            try
            {
                SqlParameter dt_start = new SqlParameter("@DT", dt);
                return context.Database.SqlQuery<bf9_EnergySutki>("EXEC " + this.sp_bf9_es + " @DT", dt_start).ToList();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF9EnergoSutki(dt={0})", dt), eventID);
                return null;
            }
        }

    }
}
