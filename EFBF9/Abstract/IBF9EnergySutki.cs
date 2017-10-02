using EFBF9.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFBF9.Abstract
{
    public interface IBF9EnergySutki
    {
        List<bf9_EnergySutki> GetBF9EnergySutki(DateTime dt);
    }
}
