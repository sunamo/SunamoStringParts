namespace SunamoStringParts;

/// <summary>
/// Provides methods for removing or keeping parts of a string based on delimiter positions.
/// </summary>
public class SHParts
{
    /// <summary>
    /// Removes everything after the last occurrence of <paramref name="delimiter"/> (including the delimiter itself).
    /// The text parameter must be first due to ChangeContent usage.
    /// </summary>
    /// <param name="text">The input string to process.</param>
    /// <param name="delimiter">The delimiter to search for.</param>
    /// <returns>The substring before the last occurrence of the delimiter, or the original string if not found.</returns>
    public static string RemoveAfterLast(string text, object delimiter)
    {
        text = text.Trim();

        var delimiterText = delimiter.ToString() ?? string.Empty;
        var index = text.LastIndexOf(delimiterText);
        if (index != -1)
        {
            var result = text.Substring(0, index);
            return result;
        }

        return text;
    }

    /// <summary>
    /// Removes everything after the first occurrence of the specified character delimiter.
    /// </summary>
    /// <param name="text">The input string to process.</param>
    /// <param name="delimiter">The character delimiter to search for.</param>
    /// <returns>The substring before the first occurrence of the delimiter.</returns>
    public static string RemoveAfterFirstChar(string text, char delimiter)
    {
        return RemoveAfterFirst(text, delimiter.ToString());
    }

    /// <summary>
    /// Removes everything after the first character matching the predicate, unless that character is in the allowed list.
    /// </summary>
    /// <param name="text">The input string to process.</param>
    /// <param name="predicate">A function that determines whether a character should trigger removal.</param>
    /// <param name="allowedCharacters">Characters that are allowed even if they match the predicate.</param>
    /// <returns>The substring before the first matching character, or the original string if no match is found.</returns>
    public static string RemoveAfterFirstFunc(string text, Func<char, bool> predicate, params char[] allowedCharacters)
    {
        text = text.Trim();
        for (var i = 0; i < text.Length; i++)
            if (predicate(text[i]))
            {
                if (allowedCharacters.Contains(text[i])) continue;
                return text.Substring(0, i);
            }

        return text;
    }

    /// <summary>
    /// Removes everything after the first occurrence of the specified character delimiter.
    /// </summary>
    /// <param name="text">The input string to process.</param>
    /// <param name="delimiter">The character delimiter to search for.</param>
    /// <returns>The substring before the first occurrence of the delimiter, or the original string if not found.</returns>
    public static string RemoveAfterFirst(string text, char delimiter)
    {
        text = text.Trim();
        var index = text.IndexOf(delimiter);
        return index == -1 || index == text.Length - 1 ? text : text.Substring(0, index);
    }

    /// <summary>
    /// Removes everything after the first occurrence of the specified string delimiter (including the delimiter itself).
    /// </summary>
    /// <param name="text">The input string to process.</param>
    /// <param name="delimiter">The string delimiter to search for.</param>
    /// <returns>The substring before the first occurrence of the delimiter, or the original string if not found.</returns>
    public static string RemoveAfterFirst(string text, string delimiter)
    {
        text = text.Trim();
        var index = text.IndexOf(delimiter);
        if (index == -1 || index == text.Length - 1) return text;
        var result = text.Remove(index);
        return result;
    }

    /// <summary>
    /// Trims the specified prefix from the start of the string repeatedly.
    /// </summary>
    /// <param name="text">The input string to process.</param>
    /// <param name="prefix">The prefix to remove from the start.</param>
    /// <returns>The string with all leading occurrences of the prefix removed.</returns>
    private static string TrimStart(string text, string prefix)
    {
        text = text.Trim();
        if (string.IsNullOrEmpty(prefix)) return text;
        var result = text;
        while (result.StartsWith(prefix)) result = result.Substring(prefix.Length);
        return result;
    }

    /// <summary>
    /// Keeps only the part of the string after the first occurrence of the specified delimiter.
    /// </summary>
    /// <param name="text">The input string to process.</param>
    /// <param name="delimiter">The delimiter to search for.</param>
    /// <param name="isKeepingDelimiter">If true, the delimiter is prepended to the result.</param>
    /// <returns>The substring after the first occurrence of the delimiter, or the original string if not found.</returns>
    public static string KeepAfterFirst(string text, string delimiter, bool isKeepingDelimiter = false)
    {
        text = text.Trim();
        var index = text.IndexOf(delimiter);
        if (index != -1)
        {
            text = TrimStart(text.Substring(index), delimiter);
            if (isKeepingDelimiter) text = delimiter + text;
        }

        return text;
    }

    /// <summary>
    /// Keeps only the part of the string after the last occurrence of the specified delimiter.
    /// </summary>
    /// <param name="text">The input string to process.</param>
    /// <param name="delimiter">The delimiter to search for.</param>
    /// <returns>The substring after the last occurrence of the delimiter, or the original string if not found.</returns>
    public static string KeepAfterLast(string text, string delimiter)
    {
        text = text.Trim();
        var index = text.LastIndexOf(delimiter);
        if (index != -1) return TrimStart(text.Substring(index), delimiter);
        return text;
    }
}