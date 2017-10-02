using EFBF7.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFBF7.Abstract
{
    public interface IBF7EnergySutki
    {
        List<bf7_EnergySutki> GetBF7EnergySutki(DateTime dt);
    }
}
