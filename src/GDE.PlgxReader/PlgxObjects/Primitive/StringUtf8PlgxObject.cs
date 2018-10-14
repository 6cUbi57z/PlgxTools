using System.Text;

namespace GDE.PlgxReader.PlgxObjects.Primitive
{
    public class StringUtf8PlgxObject : PlgxObject
    {
        protected string Data { get; }

        internal StringUtf8PlgxObject(byte[] data)
        {
            UTF8Encoding encoder = new UTF8Encoding(false, false);
            this.Data = encoder.GetString(data);
        }

        public override string ToString()
        {
            return string.Concat(base.GetPlgxObjectName(), ": ", this.Data);
        }
    }
}
