using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport.TData.Interfaces
{
    /// <summary>
    /// Холодное дутье
    /// </summary>
    public interface IColdBlast
    {
        double? ColdBlast_flow { get; }
        uFlow ColdBlast_flow_unit { get; }
        Multiplier ColdBlast_flow_multiplier { get; }
        double? ColdBlast_temp { get; }
        uTemp ColdBlast_temp_unit { get; }
        Multiplier ColdBlast_temp_multiplier { get; }
        double? ColdBlast_pressure { get; }
        uPressure ColdBlast_pressure_unit { get; }
        Multiplier ColdBlast_pressure_multiplier { get; }
        double? ColdBlast_planimetric { get; }
        uPlanimetric ColdBlast_planimetric_unit { get; }
        Multiplier ColdBlast_planimetric_multiplier { get; }
        double? ColdBlast_pr_flow { get; }
        uFlow ColdBlast_pr_flow_unit { get; }
        Multiplier ColdBlast_pr_flow_multiplier { get; }
        int? ColdBlast_time_norm { get; }
        uTime ColdBlast_time_norm_unit { get; }
        Multiplier ColdBlast_time_norm_multiplier { get; }
        int? ColdBlast_time_max { get; }
        uTime ColdBlast_time_max_unit { get; }
        Multiplier ColdBlast_time_max_multiplier { get; }
    }
}
