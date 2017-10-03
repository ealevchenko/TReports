using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport.TData.Interfaces
{
    public interface IBlastFurnaceGas_BVN
    {
        double? BFG_BVN_flow { get;}
        uFlow BFG_BVN_flow_unit { get; }
        Multiplier BFG_BVN_flow_multiplier { get; }
        double? BFG_BVN_temp { get; }
        uTemp BFG_BVN_temp_unit { get; }
        Multiplier BFG_BVN_temp_multiplier { get; }
        double? BFG_BVN_pressure { get; }
        uPressure BFG_BVN_pressure_unit { get; }
        Multiplier BFG_BVN_pressure_multiplier { get; }
        double? BFG_BVN_planimetric { get; }
        uPlanimetric BFG_BVN_planimetric_unit { get; }
        Multiplier BFG_BVN_planimetric_multiplier { get; }
        double? BFG_BVN_pr_flow { get; }
        uFlow BFG_BVN_pr_flow_unit { get; }
        Multiplier BFG_BVN_pr_flow_multiplier { get; }
        int? BFG_BVN_time_norm { get; }
        uTime BFG_BVN_time_norm_unit { get; }
        Multiplier BFG_BVN_time_norm_multiplier { get; }
        int? BFG_BVN_time_max { get; }
        uTime BFG_BVN_time_max_unit { get; }
        Multiplier BFG_BVN_time_max_multiplier { get; }
    }
}
