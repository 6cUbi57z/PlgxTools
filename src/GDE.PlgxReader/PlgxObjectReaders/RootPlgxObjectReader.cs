using System.Collections.Generic;
using System.IO;
using GDE.PlgxReader.PlgxObjects;

namespace GDE.PlgxReader.PlgxObjectReaders
{
    internal class RootPlgxObjectReader : PlgxObjectReader
    {
        public RootPlgxObjectReader(BinaryReader reader) : base(reader)
        {
        }

        public override PlgxObject ReadNextObject()
        {
            KeyValuePair<ushort, byte[]>? rawPlgxObject = this.ReadPlgxObjectFromStream();

            if (!rawPlgxObject.HasValue)
            {
                return null;
            }

            byte[] data = rawPlgxObject.Value.Value;

            // Deterime the object type.
            switch (rawPlgxObject.Value.Key)
            {
                case (ushort)PlgxObjectType.EOF:
                    this.endOfStream = true;
                    return null;

                //case (ushort)PlgxObjectType.FileUuid:
                //    throw new NotImplementedException();

                case (ushort)PlgxObjectType.BaseFileName:
                    return new BaseFileNamePlgxObject(data);

                case (ushort)PlgxObjectType.CreationTime:
                    return new CreationTimePlgxObject(data);

                case (ushort)PlgxObjectType.GeneratorName:
                    return new GeneratorNamePlgxObject(data);

                //case (ushort)PlgxObjectType.GeneratorVersion:
                //    throw new NotImplementedException();

                //case (ushort)PlgxObjectType.PrereqKP:
                //    throw new NotImplementedException();

                //case (ushort)PlgxObjectType.PrereqNet:
                //    throw new NotImplementedException();

                case (ushort)PlgxObjectType.PrereqOS:
                    return new OperatingSystemRequirementPlgxObject(data);

                //case (ushort)PlgxObjectType.PrereqPtr:
                //    throw new NotImplementedException();

                case (ushort)PlgxObjectType.BuildPre:
                    return new PreBuildPlgxObject(data);

                case (ushort)PlgxObjectType.BuildPost:
                    return new PostBuildPlgxObject(data);

                case (ushort)PlgxObjectType.BeginContent:
                    return new BeginContentPlgxObject();

                case (ushort)PlgxObjectType.File:
                    return new FilePlgxObject(data);

                case (ushort)PlgxObjectType.EndContent:
                    return new EndContentPlgxObject();

                default:
                    return new UnknownPlgxObject(data);
            }
        }
    }
}
