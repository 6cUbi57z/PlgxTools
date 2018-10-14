using System;
using System.Collections.Generic;
using System.IO;
using GDE.PlgxTools.RawPlgxObjects;

namespace GDE.PlgxTools.Reader.ObjectReaders
{
    public abstract class PlgxObjectReader
    {
        protected bool endOfStream;

        public PlgxObjectReader()
        {
        }

        protected BinaryReader BinaryReader { get; set; }

        protected KeyValuePair<ushort, byte[]>? ReadPlgxObjectFromStream()
        {
            // If we already at the end of the file, return null.
            if (this.endOfStream)
            {
                return null;
            }

            if (this.BinaryReader == null)
            {
                throw new InvalidOperationException("Attempted to read the next PLGX object from the stream but the stream has not been configured.");
            }

            // Read the object data
            ushort objectTypeRaw = this.BinaryReader.ReadUInt16();
            uint length = this.BinaryReader.ReadUInt32();
            byte[] data = (length > 0) ? this.BinaryReader.ReadBytes((int)length) : null;

            return new KeyValuePair<ushort, byte[]>(objectTypeRaw, data);
        }

        public abstract PlgxObject ReadNextObject();
    }
}
