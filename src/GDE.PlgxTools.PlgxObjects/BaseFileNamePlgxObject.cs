using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects
{
    public class BaseFileNamePlgxObject : StringUtf8PlgxObject
    {
        public string BaseFileName => base.Data;

        public BaseFileNamePlgxObject(byte[] data) : base(data)
        {
        }
    }
}
