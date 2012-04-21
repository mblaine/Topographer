using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
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
            bool biomeMap = false;
            String limitHeight = "255";
            bool biomeFoliage = true;
            bool showHeight = true;
            bool transparency = true;
            bool dryRun = false;
            bool version = false;

            OptionSet options = new OptionSet();
            options.Add("i|input=", "Path to directory containing *.mca region files. Can be relative to .minecraft/saves/.", delegate(String v) { inPath = v; });
            options.Add("o|output=", "Path including file name for where the output png will be saved.", delegate(String v) { outPath = v; });
            options.Add("r|render=", "\"terrain\" to generate a terrain map or \"biomes\" to generate a color-coded biome map instead. Default: \"terrain\".", delegate(String v) { biomeMap = (v == "biomes"); });
            options.Add("l|limit=", "Only render the world below this elevation, between 0 and 255. Default: 255.", delegate(String v) { limitHeight = v; });
            options.Add("b|biome", "Whether blocks such as grass should have their color vary based on biome. Default: enabled. Use -b+ to enable or -b- to disable.", delegate(String v) { biomeFoliage = (v != null); });
            options.Add("h|height", "Whether colors should be made lighter or darker based on elevation. Default: enabled. Use -h+ to enable or -h- to disable.", delegate(String v) { showHeight = (v != null); });
            options.Add("t|transparency", "Whether areas beneath blocks such as water or glass should be visible. Default: enabled. Use -t+ to enable or -t- to disable.", delegate(String v) { transparency = (v != null); });
            options.Add("d|dry-run", "If parameters should be parsed and any errors reported without actually doing anything.", delegate(String v) { dryRun = (v != null); });
            options.Add("?|help", "Display this help message.", delegate(String v) { help = (v != null); });
            options.Add("v|version", "Display version information.", delegate(String v) { version = (v != null); });

            options.Parse(args);

            if (version)
            {
                Console.WriteLine(String.Format("TopographerCMD (Topographer) {0}", FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion));
                Console.WriteLine();
                Console.WriteLine("Copyright 2012 Matthew Blaine.");
                Console.WriteLine("For more details including license information, please see README.txt,");
                Console.WriteLine("LICENSE.txt, or visit https://github.com/mblaine/Topographer.");
                return;
            }

            if (help || inPath == null || outPath == null)
            {
                Console.WriteLine("Usage: TopographerCMD [OPTIONS] -i [DIRECTORY] -o [FILE]");
                Console.WriteLine("Examples:");
                Console.WriteLine("TopographerCMD /l 90 /h+ /t- -input /World1/DIM-1/region -output nether.png");
                Console.WriteLine("TopographerCMD -render=biomes -i /World1/region -o World1.biomes.png");
                Console.WriteLine();
                Console.WriteLine("Options:");
                options.WriteOptionDescriptions(Console.Out);
                return;
            }

            String attempt = Path.GetFullPath(inPath);
            if (!Directory.Exists(attempt))
            {
                attempt = String.Format("{0}{1}.minecraft{1}saves{1}{2}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.DirectorySeparatorChar, inPath.TrimStart(new char[] { '\\', '/' }));
                if (!Directory.Exists(attempt))
                {
                    Console.Error.WriteLine(String.Format("ERROR: Unable to find input directory \"{0}\".", inPath));
                    return;
                }
                else
                    inPath = attempt;
            }
            else
                inPath = attempt;

            outPath = Path.GetFullPath(outPath);
            attempt = Path.GetDirectoryName(outPath);
            if (!Directory.Exists(attempt))
            {
                Console.WriteLine(String.Format("ERROR: Unable to find output directory \"{0}\".", attempt));
                return;
            }

            byte limit = 255;
            if (!biomeMap)
            {
                if (!byte.TryParse(limitHeight, out limit))
                {
                    Console.Error.WriteLine(String.Format("ERROR: Height limit must be between 0 and 255 inclusive. Unable to parse \"{0}\".", limitHeight));
                    return;
                }
            }

            Console.WriteLine(String.Format("Input: {0}", inPath));
            Console.WriteLine(String.Format("Output: {0}", outPath));
            Console.WriteLine(String.Format("Rendering: {0}", biomeMap ? "biome map" : "terrain map"));
            if (!biomeMap)
            {
                Console.WriteLine(String.Format("Rendering layers beginning at: {0}", limitHeight));
                if (biomeFoliage)
                    Console.WriteLine("Blocks such as grass will have their color vary based on biome.");
                else
                    Console.WriteLine("Blocks such as grass will be their default color regardless of biome.");
                if (showHeight)
                    Console.WriteLine("Blocks will be lighter or darker in color depending on elevation");
                else
                    Console.WriteLine("Blocks of the same type will have the same brightness regardless of elevation.");
                if (transparency)
                    Console.WriteLine("Blocks such as water and glass will have transparency.");
                else
                    Console.WriteLine("All blocks will be opaque.");
            }

            Renderer r = new Renderer(inPath, outPath, Console.Out);
            r.LimitHeight = limit;
            r.ConsiderBiomes = biomeFoliage;
            r.ShowHeight = showHeight;
            r.Transparency = transparency;
            r.BiomeOverlay = biomeMap;

            if (dryRun)
                Console.WriteLine(String.Format("Found {0} *.mcr region files.", Renderer.GetRegionCount(inPath)));
            else
                r.Render();
        }
    }
}
