using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects
{
    public class DotNetVersionRequirementPlgxObject : UInt64PlgxObject
    {
        public ulong RequiredDotNetVersion => base.Data;

        public DotNetVersionRequirementPlgxObject(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", this.RequiredDotNetVersion);
        }
    }
}
