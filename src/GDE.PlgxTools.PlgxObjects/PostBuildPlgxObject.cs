using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects
{
    public class PostBuildPlgxObject : StringUtf8PlgxObject
    {
        public string PostBuildCommand => base.Data;

        public PostBuildPlgxObject(byte[] data) : base(data)
        {
        }
    }
}
