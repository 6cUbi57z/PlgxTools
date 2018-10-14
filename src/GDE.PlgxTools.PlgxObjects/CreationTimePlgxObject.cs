using System;
using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects
{
    public class CreationTimePlgxObject : DateTimeUtcPlgxObject
    {
        public DateTime CreationTime => base.Data;

        public CreationTimePlgxObject(byte[] data) : base(data)
        {
        }
    }
}
