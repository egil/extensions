﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Net.Http;
using Microsoft.Extensions.Telemetry.Enrichment;

namespace Microsoft.Extensions.Http.Telemetry.Logging.Test.Internal;

internal class EmptyEnricher : IHttpClientLogEnricher
{
    public void Enrich(IEnrichmentTagCollector collector, HttpRequestMessage? request = null, HttpResponseMessage? response = null)
    {
        // intentionally left empty.
    }
}
