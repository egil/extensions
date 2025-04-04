﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Microsoft.Extensions.Resilience.FaultInjection;

internal sealed class FaultInjectionExceptionOptions
{
    public Exception Exception { get; set; } = new InjectedFaultException();
}
