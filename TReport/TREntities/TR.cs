using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TReport.App_LocalResources;
using TReport.TData;

namespace TReport.TREntities
{

    public class TR
    {
        protected List<trObj> trObjs = new List<trObj>();

        public TR(trObj trObj)
        {
            this.trObjs.Add(trObj);
        }

        public TR(trObj[] trObjs) {
            this.trObjs = trObjs.ToList();
        }

        public TR(List<trObj> trObjs) {
            this.trObjs = trObjs;
        }

        /// <summary>
        /// Получить строку с учетом культуры
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(Resources));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
    }
}
