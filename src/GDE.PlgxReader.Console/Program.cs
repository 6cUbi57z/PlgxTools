using System;
using GDE.PlgxReader.PlgxObjects;

namespace GDE.PlgxReader.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.Error.WriteLine("You must provide a path to a PLGX file.");
                Exit(1);
            }

            string plgxPath = args[0];
            using (KeePassPluginReader reader = new KeePassPluginReader(args[0]))
            {
                PlgxObject plgxObject;

                while ((plgxObject = reader.ReadNextObject()) != null)
                {
                    System.Console.WriteLine(plgxObject.ToString());
                }
            }

            Exit(0);
        }

        private static void Exit(int exitCode)
        {
#if DEBUG
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
#endif
            Environment.Exit(exitCode);
        }
    }
}
