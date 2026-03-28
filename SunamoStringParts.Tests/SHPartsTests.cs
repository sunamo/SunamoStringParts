namespace SunamoStringParts.Tests;

/// <summary>
/// Tests for <see cref="SHParts"/> string partitioning methods.
/// </summary>
public class SHPartsTests
{
    /// <summary>
    /// Tests that KeepAfterFirst returns the part after the first delimiter.
    /// </summary>
    [Fact]
    public void KeepAfterFirstTest()
    {
        var text = "1+kk 52 m²";
        var result = SHParts.KeepAfterFirst(text, " ");
        Assert.Equal("52 m²", result);
    }

    /// <summary>
    /// Tests that KeepAfterFirst with isKeepingDelimiter returns the delimiter prepended to the result.
    /// </summary>
    [Fact]
    public void KeepAfterFirstWithDelimiterTest()
    {
        var text = "hello-world-test";
        var result = SHParts.KeepAfterFirst(text, "-", true);
        Assert.Equal("-world-test", result);
    }

    /// <summary>
    /// Tests that KeepAfterFirst returns original text when delimiter is not found.
    /// </summary>
    [Fact]
    public void KeepAfterFirstNotFoundTest()
    {
        var text = "hello";
        var result = SHParts.KeepAfterFirst(text, "-");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Tests that RemoveAfterFirst with string delimiter removes everything after the first occurrence.
    /// </summary>
    [Fact]
    public void RemoveAfterFirstTest()
    {
        var text = "1+kk 52 m²";
        var result = SHParts.RemoveAfterFirst(text, " ");
        Assert.Equal("1+kk", result);
    }

    /// <summary>
    /// Tests that RemoveAfterFirst with char delimiter removes everything after the first occurrence.
    /// </summary>
    [Fact]
    public void RemoveAfterFirstCharTest()
    {
        var text = "hello.world.test";
        var result = SHParts.RemoveAfterFirst(text, '.');
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Tests that RemoveAfterFirstChar removes everything after the first char occurrence.
    /// </summary>
    [Fact]
    public void RemoveAfterFirstCharMethodTest()
    {
        var text = "file.name.txt";
        var result = SHParts.RemoveAfterFirstChar(text, '.');
        Assert.Equal("file", result);
    }

    /// <summary>
    /// Tests that RemoveAfterLast removes everything after the last delimiter occurrence.
    /// </summary>
    [Fact]
    public void RemoveAfterLastTest()
    {
        var text = "path.to.file.txt";
        var result = SHParts.RemoveAfterLast(text, ".");
        Assert.Equal("path.to.file", result);
    }

    /// <summary>
    /// Tests that RemoveAfterLast returns the original text when delimiter is not found.
    /// </summary>
    [Fact]
    public void RemoveAfterLastNotFoundTest()
    {
        var text = "nodelimiter";
        var result = SHParts.RemoveAfterLast(text, ".");
        Assert.Equal("nodelimiter", result);
    }

    /// <summary>
    /// Tests that RemoveAfterFirstFunc removes after the first matching character.
    /// </summary>
    [Fact]
    public void RemoveAfterFirstFuncTest()
    {
        var text = "hello123world";
        var result = SHParts.RemoveAfterFirstFunc(text, char.IsDigit);
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Tests that RemoveAfterFirstFunc respects allowed characters.
    /// </summary>
    [Fact]
    public void RemoveAfterFirstFuncWithAllowedTest()
    {
        var text = "hello1world2test";
        var result = SHParts.RemoveAfterFirstFunc(text, char.IsDigit, '1');
        Assert.Equal("hello1world", result);
    }

    /// <summary>
    /// Tests that KeepAfterLast returns the part after the last delimiter.
    /// </summary>
    [Fact]
    public void KeepAfterLastTest()
    {
        var text = "path.to.file.txt";
        var result = SHParts.KeepAfterLast(text, ".");
        Assert.Equal("txt", result);
    }

    /// <summary>
    /// Tests that KeepAfterLast returns original text when delimiter is not found.
    /// </summary>
    [Fact]
    public void KeepAfterLastNotFoundTest()
    {
        var text = "nodelimiter";
        var result = SHParts.KeepAfterLast(text, ".");
        Assert.Equal("nodelimiter", result);
    }
}
