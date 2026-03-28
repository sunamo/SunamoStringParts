### SunamoStringParts

Removing / keeping parts of a string according to the position of a substring in it.

Part of PlatformIndependentNuGetPackages:

- [nuget.org](https://www.nuget.org/profiles/sunamo)
- [github.org](https://github.com/sunamo/PlatformIndependentNuGetPackages)

Another links:

- [Developer site](https://sunamo.cz)

Request for new features / bug report / etc: [Mail](mailto:radek.jancik@sunamo.cz) or on GitHub

## API

### SHParts

| Method | Description |
|---|---|
| `RemoveAfterLast(text, delimiter)` | Removes everything after the last occurrence of the delimiter |
| `RemoveAfterFirst(text, delimiter)` | Removes everything after the first occurrence of the delimiter |
| `RemoveAfterFirstChar(text, delimiter)` | Removes everything after the first occurrence of the char delimiter |
| `RemoveAfterFirstFunc(text, predicate, allowedCharacters)` | Removes after the first char matching the predicate (with exceptions) |
| `KeepAfterFirst(text, delimiter, isKeepingDelimiter)` | Keeps only the part after the first occurrence of the delimiter |
| `KeepAfterLast(text, delimiter)` | Keeps only the part after the last occurrence of the delimiter |

## Target Frameworks

**TargetFrameworks:** `net10.0;net9.0;net8.0`
