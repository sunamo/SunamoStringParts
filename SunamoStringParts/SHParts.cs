namespace SunamoStringParts;

public class SHParts
{
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

    public static string RemoveAfterFirstChar(string text, char delimiter)
    {
        return RemoveAfterFirst(text, delimiter.ToString());
    }

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

    public static string RemoveAfterFirst(string text, char delimiter)
    {
        text = text.Trim();
        var index = text.IndexOf(delimiter);
        return index == -1 || index == text.Length - 1 ? text : text.Substring(0, index);
    }

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

    public static string KeepAfterLast(string text, string delimiter)
    {
        text = text.Trim();
        var index = text.LastIndexOf(delimiter);
        if (index != -1) return TrimStart(text.Substring(index), delimiter);
        return text;
    }
}
