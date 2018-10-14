using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects
{
    public class GeneratorNamePlgxObject : StringUtf8PlgxObject
    {
        public string GeneratorName => base.Data;

        public GeneratorNamePlgxObject(byte[] data) : base(data)
        {
        }
    }
}
