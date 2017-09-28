using EFBF9.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBF9.Abstract
{
    public interface IBF9UnloadBunker
    {
        #region BF9UnloadBunker
        List<UnloadBunker> GetBF9UnloadBunker(DateTime start, DateTime stop);

        #endregion
    }
}
