
using System;
using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects
{
    public class UuidPlgxObject : RawPlgxObject
    {
        public byte[] Uuid => base.Data;

        public UuidPlgxObject(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", BitConverter.ToString(this.Uuid));
        }
    }
}
