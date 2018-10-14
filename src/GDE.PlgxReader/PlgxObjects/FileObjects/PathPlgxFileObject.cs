using GDE.PlgxReader.PlgxObjects.Primitive;

namespace GDE.PlgxReader.PlgxObjects.FileObjects
{
    public class PathPlgxFileObject : StringUtf8PlgxObject
    {
        public string FilePath => base.Data;

        internal PathPlgxFileObject(byte[] data) : base(data)
        {
        }
    }
}
