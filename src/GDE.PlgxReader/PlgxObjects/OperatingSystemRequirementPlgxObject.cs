using GDE.PlgxReader.PlgxObjects.Primitive;

namespace GDE.PlgxReader.PlgxObjects
{
    public class OperatingSystemRequirementPlgxObject : StringUtf8PlgxObject
    {
        public string RequiredOperatingSystem => base.Data;

        internal OperatingSystemRequirementPlgxObject(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", this.RequiredOperatingSystem);
        }
    }
}
