using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects
{
    public class PointerSizeRequirementPlgxObject : UInt32PlgxObject
    {
        public uint RequiredPointerSize => base.Data;

        public PointerSizeRequirementPlgxObject(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", this.RequiredPointerSize);
        }
    }
}
