using EFBF8.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFBF8.Abstract
{
    public interface IBF8EnergySutki
    {
        List<bf8_EnergySutki> GetBF8EnergySutki(DateTime dt);
    }
}
