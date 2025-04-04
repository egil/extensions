﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.Telemetry.Latency;

/// <summary>
/// Represents a registered measure.
/// </summary>
[SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types", Justification = "Comparing instances is not an expected scenario")]
public readonly struct MeasureToken
{
    /// <summary>
    /// Gets the name of the measure.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the position of the token in the token table.
    /// </summary>
    public int Position { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MeasureToken"/> struct.
    /// </summary>
    /// <param name="name">Name of the measure.</param>
    /// <param name="position">Position of the token in the token table.</param>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
    public MeasureToken(string name, int position)
    {
        Name = Throw.IfNullOrWhitespace(name);
        Position = position;
    }
}
