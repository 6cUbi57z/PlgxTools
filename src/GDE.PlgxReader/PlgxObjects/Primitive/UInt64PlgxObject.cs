using System;

namespace GDE.PlgxReader.PlgxObjects.Primitive
{
    public abstract class UInt64PlgxObject : PlgxObject
    {
        protected ulong Data { get; }

        internal UInt64PlgxObject(byte[] data)
        {
            this.Data = ConvertToULong(data);
        }

        private static ulong ConvertToULong(byte[] data)
        {
            // From KeePass MemUtils.BytesToUInt64

            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if (data.Length != 8)
            {
                throw new ArgumentOutOfRangeException("data");
            }

            return ((ulong)data[0] | ((ulong)data[1] << 8) | ((ulong)data[2] << 16) |
                ((ulong)data[3] << 24) | ((ulong)data[4] << 32) | ((ulong)data[5] << 40) |
                ((ulong)data[6] << 48) | ((ulong)data[7] << 56));
        }


        public override string ToString()
        {
            return string.Concat(base.GetPlgxObjectName(), ": ", this.Data);
        }
    }
}
