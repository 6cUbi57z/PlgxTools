using GDE.PlgxReader.PlgxObjects.Primitive;

namespace GDE.PlgxReader.PlgxObjects
{
    public class OperatingSystemRequirementPlgxObject : StringUtf8PlgxObject
    {
        public string BaseFileName => base.Data;

        internal OperatingSystemRequirementPlgxObject(byte[] data) : base(data)
        {
        }
    }
}
