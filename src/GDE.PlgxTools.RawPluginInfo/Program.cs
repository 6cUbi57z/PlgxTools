using System;
using GDE.ConsoleHelper;
using GDE.PlgxTools.RawPlgxObjects;
using GDE.PlgxTools.Reader;
using GDE.PlgxTools.Reader.ObjectReaders;

namespace GDE.PlgxTools.RawPluginInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("You must provide a path to a PLGX file.");
                ConsoleUtils.Exit(1);
            }
            string plgxPath = args[0];

            Console.WriteLine($"PLGX File: {plgxPath}");
            Console.WriteLine();

            using (KeePassPluginReader reader = new KeePassPluginReader(plgxPath))
            {
                PlgxObject plgxObject;

                while ((plgxObject = reader.ReadNextObject()) != null)
                {
                    if (plgxObject is FilePlgxObject)
                    {
                        using (FilePlgxObjectReader filePlgxObjectReader = new FilePlgxObjectReader((FilePlgxObject)plgxObject))
                        {
                            PlgxObject plgxFileObject;
                            while ((plgxFileObject = filePlgxObjectReader.ReadNextObject()) != null)
                            {
                                Console.WriteLine(plgxFileObject.ToString());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(plgxObject.ToString());
                    }
                }
            }

            ConsoleUtils.Exit(0);
        }
    }
}
