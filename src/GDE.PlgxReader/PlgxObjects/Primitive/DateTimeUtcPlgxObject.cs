using System;

namespace GDE.PlgxReader.PlgxObjects.Primitive
{
    public abstract class DateTimeUtcPlgxObject : StringUtf8PlgxObject
    {
        protected new DateTime Data { get; }

        internal DateTimeUtcPlgxObject(byte[] data) : base(data)
        {
            this.Data = DateTime.Parse(base.Data);
        }

        public override string ToString()
        {
            return string.Concat(base.GetPlgxObjectName(), ": ", this.Data);
        }
    }
}
