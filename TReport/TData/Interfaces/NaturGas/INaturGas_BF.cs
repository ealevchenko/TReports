using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport.TData.Interfaces
{
    public interface INaturGas_BF
    {
        double? NG_BF_flow { get;}
        uFlow NG_BF_flow_unit { get; }
        Multiplier NG_BF_flow_multiplier { get; }
        double? NG_BF_temp { get; }
        uTemp NG_BF_temp_unit { get; }
        Multiplier NG_BF_temp_multiplier { get; }
        double? NG_BF_pressure { get; }
        uPressure NG_BF_pressure_unit { get; }
        Multiplier NG_BF_pressure_multiplier { get; }
        double? NG_BF_planimetric { get; }
        uPlanimetric NG_BF_planimetric_unit { get; }
        Multiplier NG_BF_planimetric_multiplier { get; }
        double? NG_BF_pr_flow { get; }
        uFlow NG_BF_pr_flow_unit { get; }
        Multiplier NG_BF_pr_flow_multiplier { get; }
        int? NG_BF_time_norm { get; }
        uTime NG_BF_time_norm_unit { get; }
        Multiplier NG_BF_time_norm_multiplier { get; }
        int? NG_BF_time_max { get; }
        uTime NG_BF_time_max_unit { get; }
        Multiplier NG_BF_time_max_multiplier { get; }
    }
}
