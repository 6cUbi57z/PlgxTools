using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.RawPlgxObjects.FileObjects
{
    public class FilePathPlgxObject : StringUtf8PlgxObject
    {
        public string FilePath => base.Data;

        public FilePathPlgxObject(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", this.FilePath);
        }
    }
}
