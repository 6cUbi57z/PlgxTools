using GDE.PlgxReader.PlgxObjects.Primitive;

namespace GDE.PlgxReader.PlgxObjects
{
    public class KeePassVersionRequirementPlgxObject : UInt64PlgxObject
    {
        public ulong RequiredKeePassVersion => base.Data;

        internal KeePassVersionRequirementPlgxObject(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", this.RequiredKeePassVersion);
        }
    }
}
