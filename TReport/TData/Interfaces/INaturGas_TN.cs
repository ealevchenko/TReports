using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport.TData.Interfaces
{
    public interface INaturGas_TN
    {
        double? NG_TN_flow { get;}
        uFlow NG_TN_flow_unit { get; }
        Multiplier NG_TN_flow_multiplier { get; }
        double? NG_TN_temp { get; }
        uTemp NG_TN_temp_unit { get; }
        Multiplier NG_TN_temp_multiplier { get; }
        double? NG_TN_pressure { get; }
        uPressure NG_TN_pressure_unit { get; }
        Multiplier NG_TN_pressure_multiplier { get; }
        double? NG_TN_planimetric { get; }
        uPlanimetric NG_TN_planimetric_unit { get; }
        Multiplier NG_TN_planimetric_multiplier { get; }
        double? NG_TN_pr_flow { get; }
        uFlow NG_TN_pr_flow_unit { get; }
        Multiplier NG_TN_pr_flow_multiplier { get; }
        int? NG_TN_time_norm { get; }
        uTime NG_TN_time_norm_unit { get; }
        Multiplier NG_TN_time_norm_multiplier { get; }
        int? NG_TN_time_max { get; }
        uTime NG_TN_time_max_unit { get; }
        Multiplier NG_TN_time_max_multiplier { get; }
    }
}
