using GDE.PlgxReader.PlgxObjects.Primitive;

namespace GDE.PlgxReader.PlgxObjects
{
    public class PointerSizeRequirementPlgxObject : UInt32PlgxObject
    {
        public uint RequiredPointerSize => base.Data;

        internal PointerSizeRequirementPlgxObject(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", this.RequiredPointerSize);
        }
    }
}
