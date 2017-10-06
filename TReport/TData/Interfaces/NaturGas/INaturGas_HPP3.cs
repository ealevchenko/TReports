using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport.TData.Interfaces
{
    public interface INaturGas_HPP3
    {
        double? NG_HPP3_flow { get; }
        uFlow NG_HPP3_flow_unit { get; }
        Multiplier NG_HPP3_flow_multiplier { get; }
        double? NG_HPP3_temp { get; }
        uTemp NG_HPP3_temp_unit { get; }
        Multiplier NG_HPP3_temp_multiplier { get; }
        double? NG_HPP3_pressure { get; }
        uPressure NG_HPP3_pressure_unit { get; }
        Multiplier NG_HPP3_pressure_multiplier { get; }
        double? NG_HPP3_planimetric { get; }
        uPlanimetric NG_HPP3_planimetric_unit { get; }
        Multiplier NG_HPP3_planimetric_multiplier { get; }
        double? NG_HPP3_pr_flow { get; }
        uFlow NG_HPP3_pr_flow_unit { get; }
        Multiplier NG_HPP3_pr_flow_multiplier { get; }
        int? NG_HPP3_time_norm { get; }
        uTime NG_HPP3_time_norm_unit { get; }
        Multiplier NG_HPP3_time_norm_multiplier { get; }
        int? NG_HPP3_time_max { get; }
        uTime NG_HPP3_time_max_unit { get; }
        Multiplier NG_HPP3_time_max_multiplier { get; }
    }
}
