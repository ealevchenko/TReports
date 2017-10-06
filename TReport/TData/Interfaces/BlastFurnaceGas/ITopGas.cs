using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport.TData.Interfaces
{
    public interface ITopGas
    {
        double? TopGas_flow { get;}
        uFlow TopGas_flow_unit { get; }
        Multiplier TopGas_flow_multiplier { get; }
        double? TopGas_temp { get; }
        uTemp TopGas_temp_unit { get; }
        Multiplier TopGas_temp_multiplier { get; }
        double? TopGas_pressure { get; }
        uPressure TopGas_pressure_unit { get; }
        Multiplier TopGas_pressure_multiplier { get; }
        double? TopGas_planimetric { get; }
        uPlanimetric TopGas_planimetric_unit { get; }
        Multiplier TopGas_planimetric_multiplier { get; }
        double? TopGas_pr_flow { get; }
        uFlow TopGas_pr_flow_unit { get; }
        Multiplier TopGas_pr_flow_multiplier { get; }
        int? TopGas_time_norm { get; }
        uTime TopGas_time_norm_unit { get; }
        Multiplier TopGas_time_norm_multiplier { get; }
        int? TopGas_time_max { get; }
        uTime TopGas_time_max_unit { get; }
        Multiplier TopGas_time_max_multiplier { get; }
    }
}
