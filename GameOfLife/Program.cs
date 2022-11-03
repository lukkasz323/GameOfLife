using System.Runtime.Versioning;

namespace GameOfLife;

[SupportedOSPlatform("windows")]
class Program
{
    private static void Main(string[] args)
    {
        Life life = new(args);

        life.Run();
    }
}

