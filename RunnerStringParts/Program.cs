using SunamoStringParts;
using SunamoStringParts.Tests;

namespace RunnerStringParts;

internal class Program
{
    static void Main()
    {
        SHPartsTests t = new();
        t.KeepAfterFirstTest();
        t.RemoveAfterFirstTest();
    }
}
