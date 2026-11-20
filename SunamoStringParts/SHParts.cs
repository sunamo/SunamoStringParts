namespace SunamoStringParts;

/// <summary>
/// Represents the SH parts type.
/// </summary>
public class SHParts
{
    /// <summary>
    /// Remove after last.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The remove after last result.</returns>
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
    /// Remove after first char.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The remove after first char result.</returns>
    public static string RemoveAfterFirstChar(string text, char delimiter)
    {
        return RemoveAfterFirst(text, delimiter.ToString());
    }

    /// <summary>
    /// Remove after first func.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="predicate">The predicate.</param>
    /// <param name="allowedCharacters">The allowed characters.</param>
    /// <returns>The remove after first func result.</returns>
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
    /// Remove after first.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The remove after first result.</returns>
    public static string RemoveAfterFirst(string text, char delimiter)
    {
        text = text.Trim();
        var index = text.IndexOf(delimiter);
        return index == -1 || index == text.Length - 1 ? text : text.Substring(0, index);
    }

    /// <summary>
    /// Remove after first.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The remove after first result.</returns>
    public static string RemoveAfterFirst(string text, string delimiter)
    {
        text = text.Trim();
        var index = text.IndexOf(delimiter);
        if (index == -1 || index == text.Length - 1) return text;
        var result = text.Remove(index);
        return result;
    }

    private static string TrimStart(string text, string prefix)
    {
        text = text.Trim();
        if (string.IsNullOrEmpty(prefix)) return text;
        var result = text;
        while (result.StartsWith(prefix)) result = result.Substring(prefix.Length);
        return result;
    }

    /// <summary>
    /// Keep after first.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="isKeepingDelimiter">The is keeping delimiter.</param>
    /// <returns>The keep after first result.</returns>
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
    /// Keep after last.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The keep after last result.</returns>
    public static string KeepAfterLast(string text, string delimiter)
    {
        text = text.Trim();
        var index = text.LastIndexOf(delimiter);
        if (index != -1) return TrimStart(text.Substring(index), delimiter);
        return text;
    }
}
