using GDE.PlgxReader.PlgxObjects.Primitive;

namespace GDE.PlgxReader.PlgxObjects
{
    public class DotNetVersionRequirementPlgxObject : UInt64PlgxObject
    {
        public ulong RequiredDotNetVersion => base.Data;

        internal DotNetVersionRequirementPlgxObject(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", this.RequiredDotNetVersion);
        }
    }
}
