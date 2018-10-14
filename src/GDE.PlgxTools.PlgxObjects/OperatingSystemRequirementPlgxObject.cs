using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects
{
    public class OperatingSystemRequirementPlgxObject : StringUtf8PlgxObject
    {
        public string RequiredOperatingSystem => base.Data;

        public OperatingSystemRequirementPlgxObject(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", this.RequiredOperatingSystem);
        }
    }
}
