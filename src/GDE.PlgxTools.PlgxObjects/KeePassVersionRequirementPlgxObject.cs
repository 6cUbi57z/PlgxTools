using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects
{
    public class KeePassVersionRequirementPlgxObject : UInt64PlgxObject
    {
        public ulong RequiredKeePassVersion => base.Data;

        public KeePassVersionRequirementPlgxObject(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", this.RequiredKeePassVersion);
        }
    }
}
