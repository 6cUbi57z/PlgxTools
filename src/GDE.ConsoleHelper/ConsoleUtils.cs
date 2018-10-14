using System;
using System.Diagnostics;

namespace GDE.ConsoleHelper
{
    public static class ConsoleUtils
    {
        public static void Exit(int exitCode)
        {
            if (Debugger.IsAttached)
            {
                System.Console.WriteLine("Press any key to exit...");
                System.Console.ReadKey();
            }

            Environment.Exit(exitCode);
        }
    }
}
