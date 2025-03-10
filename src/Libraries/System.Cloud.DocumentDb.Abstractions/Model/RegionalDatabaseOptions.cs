﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace System.Cloud.DocumentDb;

/// <summary>
/// Represents region-specific configurations for databases.
/// </summary>
public class RegionalDatabaseOptions
{
    /// <summary>
    /// Gets or sets the regional database name.
    /// </summary>
    /// <value>The default value is <see langword="null" />.</value>
    /// <remarks>
    /// If the value is not specified, <see cref="DatabaseOptions.DefaultRegionalDatabaseName"/> is used.
    /// </remarks>
    public string? DatabaseName { get; set; }

    /// <summary>
    /// Gets or sets the regional database endpoint.
    /// </summary>
    /// <remarks>
    /// The value is required.
    /// </remarks>
    [Required]
    public Uri? Endpoint { get; set; }

    /// <summary>
    /// Gets or sets the key to the account or resource token.
    /// </summary>
    /// <value>The default value is <see langword="null" />.</value>
    public string? PrimaryKey { get; set; }

    /// <summary>
    /// Gets or sets a list of preferred regions used for SDK to define failover order for regional database.
    /// </summary>
    /// <value>
    /// The default value is an empty <see cref="Dictionary{TKey, TValue}" />.
    /// </value>
    [SuppressMessage("Usage", "CA2227:Collection properties should be read only",
        Justification = "Options pattern.")]
    public IList<string> FailoverRegions { get; set; }
        = new List<string>();
}
