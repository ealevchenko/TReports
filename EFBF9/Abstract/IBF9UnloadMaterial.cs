using EFBF9.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBF9.Abstract
{
    public interface IBF9UnloadMaterial
    {
        #region BF9UnloadMaterial
        List<UnloadMaterialSmena> GetBF9UnloadMaterialSmena(DateTime dt);
        #endregion
    }
}
