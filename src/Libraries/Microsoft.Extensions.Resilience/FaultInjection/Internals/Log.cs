﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.Resilience.FaultInjection;

internal static partial class Log
{
    [LoggerMessage(0, LogLevel.Information,
        "Fault-injection group name: {groupName}. " +
        "Fault type: {faultType}. " +
        "Injected value: {injectedValue}. ")]
    public static partial void LogInjection(
        ILogger logger,
        string groupName,
        string faultType,
        string injectedValue);
}
