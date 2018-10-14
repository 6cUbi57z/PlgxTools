using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects
{
    public class GeneratorVersionPlgxObject : UInt64PlgxObject
    {
        public ulong GeneratorVersion => base.Data;

        public GeneratorVersionPlgxObject(byte[] data) : base(data)
        {
        }
    }
}
