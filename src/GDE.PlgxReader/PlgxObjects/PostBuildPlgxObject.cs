using GDE.PlgxReader.PlgxObjects.Primitive;

namespace GDE.PlgxReader.PlgxObjects
{
    public class PostBuildPlgxObject : StringUtf8PlgxObject
    {
        public string PostBuildCommand => base.Data;

        internal PostBuildPlgxObject(byte[] data) : base(data)
        {
        }
    }
}
