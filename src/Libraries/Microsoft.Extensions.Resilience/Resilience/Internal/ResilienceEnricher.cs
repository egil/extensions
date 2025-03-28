﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Diagnostics.ExceptionSummarization;
using Microsoft.Extensions.Http.Telemetry;
using Microsoft.Extensions.Options;
using Polly.Extensions.Telemetry;

namespace Microsoft.Extensions.Resilience.Resilience.Internal;

internal sealed class ResilienceEnricher
{
    private readonly FrozenDictionary<Type, Func<object, FailureResultContext>> _faultFactories;
    private readonly IOutgoingRequestContext? _outgoingRequestContext;
    private readonly IExceptionSummarizer _exceptionSummarizer;

    public ResilienceEnricher(
        IOptions<FailureEventMetricsOptions> metricsOptions,
        IEnumerable<IOutgoingRequestContext> outgoingRequestContext,
        IExceptionSummarizer exceptionSummarizer)
    {
        _faultFactories = metricsOptions.Value.Factories.ToFrozenDictionary();
        _outgoingRequestContext = outgoingRequestContext.FirstOrDefault();
        _exceptionSummarizer = exceptionSummarizer;
    }

    public void Enrich(EnrichmentContext context)
    {
        if (context.Outcome?.Exception is Exception e)
        {
            context.Tags.Add(new(ResilienceTagNames.FailureSource, e.Source));
            context.Tags.Add(new(ResilienceTagNames.FailureReason, e.GetType().Name));
            context.Tags.Add(new(ResilienceTagNames.FailureSummary, _exceptionSummarizer.Summarize(e).ToString()));
        }
        else if (context.Outcome?.Result is object result && _faultFactories.TryGetValue(result.GetType(), out var factory))
        {
            var failureContext = factory(result);
            context.Tags.Add(new(ResilienceTagNames.FailureSource, failureContext.FailureSource));
            context.Tags.Add(new(ResilienceTagNames.FailureReason, failureContext.FailureReason));
            context.Tags.Add(new(ResilienceTagNames.FailureSummary, failureContext.AdditionalInformation));
        }
        else
        {
            context.Tags.Add(new(ResilienceTagNames.FailureSource, null));
            context.Tags.Add(new(ResilienceTagNames.FailureReason, null));
            context.Tags.Add(new(ResilienceTagNames.FailureSummary, null));
        }

        var requestMetadata = context.Context.GetRequestMetadata() ?? _outgoingRequestContext?.RequestMetadata;
        if (requestMetadata is not null)
        {
            context.Tags.Add(new(ResilienceTagNames.RequestName, requestMetadata.RequestName));
            context.Tags.Add(new(ResilienceTagNames.DependencyName, requestMetadata.DependencyName));
        }
        else
        {
            context.Tags.Add(new(ResilienceTagNames.RequestName, null));
            context.Tags.Add(new(ResilienceTagNames.DependencyName, null));
        }
    }
}
