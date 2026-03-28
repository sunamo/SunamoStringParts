# SunamoStringParts

Removing / keeping parts of a string according to the position of a substring in it.

## Overview

SunamoStringParts is part of the Sunamo package ecosystem, providing modular, platform-independent utilities for .NET development.

## Main Components

### Key Classes

- **SHParts**

### Key Methods

- `RemoveAfterLast(text, delimiter)` - Removes everything after the last occurrence of the delimiter
- `RemoveAfterFirst(text, delimiter)` - Removes everything after the first occurrence of the delimiter (char or string overload)
- `RemoveAfterFirstChar(text, delimiter)` - Removes everything after the first char delimiter
- `RemoveAfterFirstFunc(text, predicate, allowedCharacters)` - Removes after the first char matching the predicate
- `KeepAfterFirst(text, delimiter, isKeepingDelimiter)` - Keeps only the part after the first occurrence of the delimiter
- `KeepAfterLast(text, delimiter)` - Keeps only the part after the last occurrence of the delimiter

## Installation

```bash
dotnet add package SunamoStringParts
```

## Dependencies

- **Microsoft.Extensions.Logging.Abstractions**

## Package Information

- **Package Name**: SunamoStringParts
- **Target Frameworks**: net10.0;net9.0;net8.0
- **Category**: Platform-Independent NuGet Package

## Related Packages

This package is part of the Sunamo package ecosystem. For more information about related packages, visit the main repository.

## License

MIT - See the repository root for license information.
