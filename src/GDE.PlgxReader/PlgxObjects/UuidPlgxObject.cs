using System;
using GDE.PlgxReader.PlgxObjects.Primitive;

namespace GDE.PlgxReader.PlgxObjects
{
    public class UuidPlgxObject : RawPlgxObject
    {
        public byte[] Uuid => base.Data;

        internal UuidPlgxObject(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", BitConverter.ToString(this.Uuid));
        }
    }
}
