﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.Extensions.Diagnostics.ResourceMonitoring;

/// <summary>
/// Represents the names of instruments published by this package.
/// </summary>
/// <seealso cref="System.Diagnostics.Metrics.Instrument"/>
public static class LinuxResourceUtilizationCounters
{
    /// <summary>
    /// Gets the CPU consumption of the running application in percentages.
    /// </summary>
    /// <remarks>
    /// The type of an instrument is <see cref="System.Diagnostics.Metrics.ObservableGauge{T}"/> (long).
    /// </remarks>
    public static string CpuConsumptionPercentage { get; } = "cpu_consumption_percentage";

    /// <summary>
    /// Gets the memory consumption of the running application in percentages.
    /// </summary>
    /// <remarks>
    /// The type of an instrument is <see cref="System.Diagnostics.Metrics.ObservableGauge{T}"/> (long).
    /// </remarks>
    public static string MemoryConsumptionPercentage { get; } = "memory_consumption_percentage";
}
