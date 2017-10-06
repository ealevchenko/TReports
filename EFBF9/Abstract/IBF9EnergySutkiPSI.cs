using EFBF9.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFBF9.Abstract
{
    public interface IBF9EnergySutkiPSI
    {
        List<bf9_EnergySutkiPSI> GetBF9EnergySutkiPSI(DateTime dt);
    }
}
