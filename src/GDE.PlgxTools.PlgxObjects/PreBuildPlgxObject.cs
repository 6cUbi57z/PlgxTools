using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects
{
    public class PreBuildPlgxObject : StringUtf8PlgxObject
    {
        public string PreBuildCommand => base.Data;

        public PreBuildPlgxObject(byte[] data) : base(data)
        {
        }
    }
}
