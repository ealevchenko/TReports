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
    public interface IHotBlast
    {
        double? HotBlast_flow { get; }
        uFlow HotBlast_flow_unit { get; }
        Multiplier HotBlast_flow_multiplier { get; }
        double? HotBlast_temp { get; }
        uTemp HotBlast_temp_unit { get; }
        Multiplier HotBlast_temp_multiplier { get; }
        double? HotBlast_pressure { get; }
        uPressure HotBlast_pressure_unit { get; }
        Multiplier HotBlast_pressure_multiplier { get; }
        double? HotBlast_planimetric { get; }
        uPlanimetric HotBlast_planimetric_unit { get; }
        Multiplier HotBlast_planimetric_multiplier { get; }
        double? HotBlast_pr_flow { get; }
        uFlow HotBlast_pr_flow_unit { get; }
        Multiplier HotBlast_pr_flow_multiplier { get; }
        int? HotBlast_time_norm { get; }
        uTime HotBlast_time_norm_unit { get; }
        Multiplier HotBlast_time_norm_multiplier { get; }
        int? HotBlast_time_max { get; }
        uTime HotBlast_time_max_unit { get; }
        Multiplier HotBlast_time_max_multiplier { get; }
    }
}
