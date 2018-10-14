using System.IO;
using GDE.PlgxReader.Models;
using GDE.PlgxTools.RawPlgxObjects;
using GDE.PlgxTools.RawPlgxObjects.FileObjects;
using GDE.PlgxTools.Reader;
using GDE.PlgxTools.Reader.ObjectReaders;
using static GDE.PlgxReader.Models.PlgxRequirements;

namespace GDE.PlgxTools
{
    public static class PlgxUtils
    {
        public static PlgxInfo ReadPlgxPlugin(string pluginFile)
        {
            PlgxInfo plgxInfo = new PlgxInfo();

            using (KeePassPluginReader reader = new KeePassPluginReader(pluginFile))
            {
                plgxInfo.InfoMetadata.Signature1 = reader.Signature1;
                plgxInfo.InfoMetadata.Signature2 = reader.Signature2;
                plgxInfo.InfoMetadata.InfoVersion = reader.PlgxVersion;

                PlgxObject nextObject;
                while ((nextObject = reader.ReadNextObject()) != null)
                {
                    if (nextObject is UuidPlgxObject)
                    {
                        plgxInfo.Uuid = ((UuidPlgxObject)nextObject).Uuid;
                    }
                    else if (nextObject is BaseFileNamePlgxObject)
                    {
                        plgxInfo.BaseFileName = ((BaseFileNamePlgxObject)nextObject).BaseFileName;
                    }
                    else if (nextObject is CreationTimePlgxObject)
                    {
                        plgxInfo.CreationTime = ((CreationTimePlgxObject)nextObject).CreationTime;
                    }
                    else if (nextObject is GeneratorNamePlgxObject)
                    {
                        plgxInfo.Generator.Name = ((GeneratorNamePlgxObject)nextObject).GeneratorName;
                    }
                    else if (nextObject is GeneratorVersionPlgxObject)
                    {
                        plgxInfo.Generator.Version = ((GeneratorVersionPlgxObject)nextObject).GeneratorVersion;
                    }
                    else if (nextObject is KeePassVersionRequirementPlgxObject)
                    {
                        plgxInfo.Requirements.KeePassVersion = ((KeePassVersionRequirementPlgxObject)nextObject).RequiredKeePassVersion;
                    }
                    else if (nextObject is DotNetVersionRequirementPlgxObject)
                    {
                        plgxInfo.Requirements.DotNetVersion = ((DotNetVersionRequirementPlgxObject)nextObject).RequiredDotNetVersion;
                    }
                    else if (nextObject is OperatingSystemRequirementPlgxObject)
                    {
                        string osRawValue = ((OperatingSystemRequirementPlgxObject)nextObject).RequiredOperatingSystem;

                        if (System.Enum.TryParse(osRawValue, out OperatingSystem os))
                        {
                            plgxInfo.Requirements.OS = os;
                        }
                        else
                        {
                            throw new InvalidDataException($"Operating system type '{osRawValue}' was not recognised.");
                        }

                    }
                    else if (nextObject is PointerSizeRequirementPlgxObject)
                    {
                        plgxInfo.Requirements.PointerSize = ((PointerSizeRequirementPlgxObject)nextObject).RequiredPointerSize;
                    }
                    else if (nextObject is PreBuildPlgxObject)
                    {
                        plgxInfo.PreBuildCommand = ((PreBuildPlgxObject)nextObject).PreBuildCommand;
                    }
                    else if (nextObject is PostBuildPlgxObject)
                    {
                        plgxInfo.PostBuildCommand = ((PostBuildPlgxObject)nextObject).PostBuildCommand;
                    }
                    else if (nextObject is BeginContentPlgxObject)
                    {
                        // Nothing to do here as this object type contains no data.
                    }
                    else if (nextObject is FilePlgxObject)
                    {
                        PlgxEmbeddedFile file = PlgxUtils.ReadEmbeddedFileFromPlgxData((FilePlgxObject)nextObject);
                        plgxInfo.Files.Add(file);
                    }
                    else if (nextObject is EndContentPlgxObject)
                    {
                        // Nothing to do here as this object type contains no data.
                    }
                    else
                    {
                        // Unrecognised plgx object type. Nothing to do.
                    }
                }

                return plgxInfo;
            }
        }

        public static void ValidatePlgxPluginMetadata(this PlgxInfo plgxInfo)
        {
            plgxInfo.InfoMetadata.Validate();
        }

        public static void Validate(this PlgxInfoMetadata plgxInfoMetadata)
        {
            if (plgxInfoMetadata.Signature1 != PlgxConstants.PlgxSignature1)
            {
                throw new IOException("Invalid Signature 1.");
            }

            if (plgxInfoMetadata.Signature2 != PlgxConstants.PlgxSignature2)
            {
                throw new IOException("Invalid Signature 2.");
            }

            if ((plgxInfoMetadata.InfoVersion & PlgxConstants.PlgxVersionMask) > (PlgxConstants.PlgxVersion & PlgxConstants.PlgxVersionMask))
            {
                throw new IOException("Invalid PLGX Version.");
            }
        }

        private static PlgxEmbeddedFile ReadEmbeddedFileFromPlgxData(FilePlgxObject plgxFileObject)
        {

            PlgxEmbeddedFile plgxFile = new PlgxEmbeddedFile();

            using (FilePlgxObjectReader reader = new FilePlgxObjectReader(plgxFileObject))
            {
                PlgxObject nextObject;
                while ((nextObject = reader.ReadNextObject()) != null)
                {
                    if (nextObject is FilePathPlgxObject)
                    {
                        plgxFile.Path = ((FilePathPlgxObject)nextObject).FilePath;
                    }
                    else
                    {
                        // Unrecognised plgx object type. Nothing to do.
                    }
                }

                return plgxFile;
            }
        }
    }
}
