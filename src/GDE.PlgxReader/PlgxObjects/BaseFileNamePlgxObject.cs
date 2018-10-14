using GDE.PlgxReader.PlgxObjects.Primitive;

namespace GDE.PlgxReader.PlgxObjects
{
    public class BaseFileNamePlgxObject : StringUtf8PlgxObject
    {
        public string BaseFileName => base.Data;

        internal BaseFileNamePlgxObject(byte[] data) : base(data)
        {
        }
    }
}
