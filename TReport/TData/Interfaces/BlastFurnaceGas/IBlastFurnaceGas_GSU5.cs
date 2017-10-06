using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport.TData.Interfaces
{
    public interface IBlastFurnaceGas_GSU5
    {
        double? BFG_GSU5_flow { get;}
        uFlow BFG_GSU5_flow_unit { get; }
        Multiplier BFG_GSU5_flow_multiplier { get; }
        double? BFG_GSU5_temp { get; }
        uTemp BFG_GSU5_temp_unit { get; }
        Multiplier BFG_GSU5_temp_multiplier { get; }
        double? BFG_GSU5_pressure { get; }
        uPressure BFG_GSU5_pressure_unit { get; }
        Multiplier BFG_GSU5_pressure_multiplier { get; }
        double? BFG_GSU5_planimetric { get; }
        uPlanimetric BFG_GSU5_planimetric_unit { get; }
        Multiplier BFG_GSU5_planimetric_multiplier { get; }
        double? BFG_GSU5_pr_flow { get; }
        uFlow BFG_GSU5_pr_flow_unit { get; }
        Multiplier BFG_GSU5_pr_flow_multiplier { get; }
        int? BFG_GSU5_time_norm { get; }
        uTime BFG_GSU5_time_norm_unit { get; }
        Multiplier BFG_GSU5_time_norm_multiplier { get; }
        int? BFG_GSU5_time_max { get; }
        uTime BFG_GSU5_time_max_unit { get; }
        Multiplier BFG_GSU5_time_max_multiplier { get; }
    }
}
