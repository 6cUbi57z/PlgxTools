using GDE.PlgxReader.PlgxObjects.Primitive;

namespace GDE.PlgxReader.PlgxObjects
{
    public class PreBuildPlgxObject : StringUtf8PlgxObject
    {
        public string PreBuildCommand => base.Data;

        internal PreBuildPlgxObject(byte[] data) : base(data)
        {
        }
    }
}
