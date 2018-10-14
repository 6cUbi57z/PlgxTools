using System;
using System.Collections.Generic;
using GDE.ConsoleHelper;
using GDE.PlgxReader.Models;

namespace GDE.PlgxTools.PluginInfo
{
    class Program
    {
        private const int SPACES_PER_INDENT_LEVEL = 2;

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("You must provide a path to a PLGX file.");
                ConsoleUtils.Exit(1);
            }
            string plgxPath = args[0];

            Console.WriteLine($"PLGX File: {plgxPath}");

            PlgxInfo plgxInfo = PlgxUtils.ReadPlgxPlugin(plgxPath);

            PrintInfoMetadata(plgxInfo.InfoMetadata);

            string indentRootLevel = "".PadLeft(SPACES_PER_INDENT_LEVEL);
            Console.WriteLine($"{indentRootLevel}UUID: {BitConverter.ToString(plgxInfo.Uuid)}");
            Console.WriteLine($"{indentRootLevel}Creation Time: {plgxInfo.CreationTime}");

            PrintGeneratorInfo(plgxInfo.Generator);
            PrintRequirements(plgxInfo.Requirements);

            Console.WriteLine($"{indentRootLevel}Pre-Build Command: {PrintableString(plgxInfo.PreBuildCommand)}");
            Console.WriteLine($"{indentRootLevel}Post-Build Command: {PrintableString(plgxInfo.PostBuildCommand)}");

            PrintFileInfo(plgxInfo.Files);

            Console.WriteLine();
            ConsoleUtils.Exit(0);
        }

        private static void PrintInfoMetadata(PlgxInfoMetadata infoMetadata, int indentationLevel = 1)
        {
            string indentRootLevel = "".PadLeft(indentationLevel * SPACES_PER_INDENT_LEVEL);
            string indentLevel2 = "".PadLeft((indentationLevel + 1) * SPACES_PER_INDENT_LEVEL);

            Console.WriteLine($"{indentRootLevel}Info Metadata:");
            Console.WriteLine($"{indentLevel2}Signature 1: {infoMetadata.Signature1}");
            Console.WriteLine($"{indentLevel2}Signature 2: {infoMetadata.Signature2}");
            Console.WriteLine($"{indentLevel2}Info Version: {infoMetadata.InfoVersion}");
        }

        private static void PrintGeneratorInfo(PlgxGenerator generator, int indentationLevel = 1)
        {
            string indentRootLevel = "".PadLeft(indentationLevel * SPACES_PER_INDENT_LEVEL);
            string indentLevel2 = "".PadLeft((indentationLevel + 1) * SPACES_PER_INDENT_LEVEL);

            Console.WriteLine($"{indentRootLevel}Generator:");
            Console.WriteLine($"{indentLevel2}Name: {PrintableString(generator.Name)}");
            Console.WriteLine($"{indentLevel2}Version: {generator.Version}");
        }

        private static void PrintRequirements(PlgxRequirements requirements, int indentationLevel = 1)
        {
            string indentRootLevel = "".PadLeft(indentationLevel * SPACES_PER_INDENT_LEVEL);
            string indentLevel2 = "".PadLeft((indentationLevel + 1) * SPACES_PER_INDENT_LEVEL);

            Console.WriteLine($"{indentRootLevel}Requirements:");
            Console.WriteLine($"{indentLevel2}KeePass Version: {PrinatbleRequirement(requirements.KeePassVersion)}");
            Console.WriteLine($"{indentLevel2}.NET Version: {PrinatbleRequirement(requirements.DotNetVersion)}");
            Console.WriteLine($"{indentLevel2}Operating System: {PrinatbleRequirement(requirements.OS)}");
            Console.WriteLine($"{indentLevel2}Pointer Size: {PrinatbleRequirement(requirements.PointerSize)}");
        }

        private static void PrintFileInfo(List<PlgxEmbeddedFile> files, int indentationLevel = 1)
        {
            string indentRootLevel = "".PadLeft(indentationLevel * SPACES_PER_INDENT_LEVEL);
            string indentLevel2 = "".PadLeft((indentationLevel + 1) * SPACES_PER_INDENT_LEVEL);

            Console.WriteLine($"{indentRootLevel}Files:");

            foreach (PlgxEmbeddedFile file in files)
            {
                Console.WriteLine($"{indentLevel2}{file.Path}");
            }
        }

        private static string PrintableString(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "(Empty String)" : value;
        }

        private static string PrinatbleRequirement(object obj)
        {
            return obj == null ? "(Not Specified)" : obj.ToString();
        }
    }
}
