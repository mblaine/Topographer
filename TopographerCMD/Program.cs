using System;
using Topographer;
using NDesk.Options;

namespace TopographerCMD
{
    class Program
    {
        static void Main(String[] args)
        {
            String inPath = null;
            String outPath = null;

            bool help = false;
            bool biomes = false;
            String limitHeight;
            bool biomeFoliage = true;
            bool showHeight = true;
            bool transparency = true;

            OptionSet options = new OptionSet();
            options.Add("i|input", "Path to directory containing *.mca region files. Can be relative to .minecraft/saves/.", delegate(String v) { inPath = v; });
            options.Add("o|output", "Path including file name for where the output png will be saved.", delegate(String v) { outPath = v; });
            options.Add("?|help", "Display this help message.", delegate(String v) { help = (v != null); });
            options.Add("r|render", "\"terrain\" to generate a terrain map or \"biomes\" to generate a color-coded biome map instead. Default: \"terrain\".", delegate(String v) { biomes = (v == "biomes"); });
            options.Add("l|limit", "Only render the world below this elevation, between 0 and 255. Default: 255.", delegate(String v) { limitHeight = v; });
            options.Add("b|biome", "Whether blocks such as grass should have their color vary based on biome. Default: enabled. Use -b+ to enable or -b- to disable.", delegate(String v) { biomeFoliage = (v != null); });
            options.Add("h|height", "Whether colors should be made lighter or darker based on elevation. Default: enabled. Use -h+ to enable or -h- to disable.", delegate(String v) { showHeight = (v != null); });
            options.Add("t|transparency", "Whether areas beneath blocks such as water or glass should be visible. Default: enabled. Use -t+ to enable or -t- to disable.", delegate(String v) { transparency = (v != null); });

            options.Parse(args);

            if (help)
            {
                Console.WriteLine("Usage: TopographerCMD [OPTIONS] -i [DIRECTORY] -o [FILE]");
                Console.WriteLine("Example: TopographerCMD /l 90 /h+ /t- -input /World1/DIM-1/regions -output World1.nether.png");
                Console.WriteLine("Example: TopographerCMD -render=biomes -i /World1/regions -o World1.biomes.png");
                Console.WriteLine("Options:");
                options.WriteOptionDescriptions(Console.Out);
            }
        }
    }
}
