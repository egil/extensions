﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace Microsoft.Gen.Logging.Parsing;

[ExcludeFromCodeCoverage]
internal sealed record class SymbolHolder(
    Compilation Compilation,
    INamedTypeSymbol LoggerMessageAttribute,
    INamedTypeSymbol LogPropertiesAttribute,
    INamedTypeSymbol? LogPropertyIgnoreAttribute,
    INamedTypeSymbol ITagCollectorSymbol,
    INamedTypeSymbol ILoggerSymbol,
    INamedTypeSymbol LogLevelSymbol,
    INamedTypeSymbol ExceptionSymbol,
    HashSet<INamedTypeSymbol> IgnorePropertiesSymbols,
    INamedTypeSymbol EnumerableSymbol,
    INamedTypeSymbol FormatProviderSymbol,
    INamedTypeSymbol? DataClassificationAttribute);
