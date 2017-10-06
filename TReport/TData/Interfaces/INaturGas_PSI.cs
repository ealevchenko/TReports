using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport.TData.Interfaces
{
    public interface INaturGas_PSI
    {
        double? NG_PSI_flow { get;}
        uFlow NG_PSI_flow_unit { get; }
        Multiplier NG_PSI_flow_multiplier { get; }
        double? NG_PSI_temp { get; }
        uTemp NG_PSI_temp_unit { get; }
        Multiplier NG_PSI_temp_multiplier { get; }
        double? NG_PSI_pressure { get; }
        uPressure NG_PSI_pressure_unit { get; }
        Multiplier NG_PSI_pressure_multiplier { get; }
        double? NG_PSI_planimetric { get; }
        uPlanimetric NG_PSI_planimetric_unit { get; }
        Multiplier NG_PSI_planimetric_multiplier { get; }
        double? NG_PSI_pr_flow { get; }
        uFlow NG_PSI_pr_flow_unit { get; }
        Multiplier NG_PSI_pr_flow_multiplier { get; }
        int? NG_PSI_time_norm { get; }
        uTime NG_PSI_time_norm_unit { get; }
        Multiplier NG_PSI_time_norm_multiplier { get; }
        int? NG_PSI_time_max { get; }
        uTime NG_PSI_time_max_unit { get; }
        Multiplier NG_PSI_time_max_multiplier { get; }
    }
}
