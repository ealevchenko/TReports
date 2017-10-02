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
        double? NG_flow { get;}
        uFlow NG_flow_unit { get; }
        Multiplier NG_flow_multiplier { get; }
        double? NG_temp { get;}
        uTemp NG_temp_unit { get; }
        Multiplier NG_temp_multiplier { get; }
        double? NG_pressure { get;}
        uPressure NG_pressure_unit { get; }
        Multiplier NG_pressure_multiplier { get; }
        double? NG_planimetric { get;}
        uPlanimetric NG_planimetric_unit { get; }
        Multiplier NG_planimetric_multiplier { get; }
        double? NG_pr_flow { get;}
        uFlow NG_pr_flow_unit { get; }
        Multiplier NG_pr_flow_multiplier { get; }
        int? NG_time_norm { get; }
        uTime NG_time_norm_unit { get; }
        Multiplier NG_time_norm_multiplier { get; }
        int? NG_time_max { get;}
        uTime NG_time_max_unit { get; }
        Multiplier NG_time_max_multiplier { get; }
    }
}
