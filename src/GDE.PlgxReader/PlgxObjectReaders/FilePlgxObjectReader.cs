using System.Collections.Generic;
using System.IO;
using GDE.PlgxReader.PlgxObjects;
using GDE.PlgxReader.PlgxObjects.FileObjects;

namespace GDE.PlgxReader.PlgxObjectReaders
{
    internal class FilePlgxObjectReader : PlgxObjectReader
    {
        public FilePlgxObjectReader(BinaryReader reader) : base(reader)
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
                case (ushort)PlgxFileObjectType.EOF:
                    this.endOfStream = true;
                    return null;

                case (ushort)PlgxFileObjectType.Path:
                    return new PathPlgxFileObject(data);

                //case (ushort)PlgxFileObjectType.Data:
                //    throw new NotImplementedException();

                default:
                    return new UnknownPlgxObject(data);
            }
        }
    }
}
