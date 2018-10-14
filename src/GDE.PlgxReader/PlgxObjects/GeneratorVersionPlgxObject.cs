using GDE.PlgxReader.PlgxObjects.Primitive;

namespace GDE.PlgxReader.PlgxObjects
{
    public class GeneratorVersionPlgxObject : UInt64PlgxObject
    {
        internal GeneratorVersionPlgxObject(byte[] data) : base(data)
        {
        }
    }
}
