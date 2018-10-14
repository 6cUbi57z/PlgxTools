using System.Collections.Generic;
using System.IO;
using GDE.PlgxReader.PlgxObjects;

namespace GDE.PlgxReader.PlgxObjectReaders
{
    internal abstract class PlgxObjectReader
    {
        private BinaryReader reader;

        protected bool endOfStream;

        public PlgxObjectReader(BinaryReader reader)
        {
            this.reader = reader;
        }

        protected KeyValuePair<ushort, byte[]>? ReadPlgxObjectFromStream()
        {
            // If we already at the end of the file, return null.
            if (this.endOfStream)
            {
                return null;
            }

            // Read the object data
            ushort objectTypeRaw = this.reader.ReadUInt16();
            uint length = this.reader.ReadUInt32();
            byte[] data = (length > 0) ? this.reader.ReadBytes((int)length) : null;

            return new KeyValuePair<ushort, byte[]>(objectTypeRaw, data);
        }

        public abstract PlgxObject ReadNextObject();
    }
}
