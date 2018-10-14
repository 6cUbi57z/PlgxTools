using System;

namespace GDE.PlgxReader.PlgxObjects.Primitive
{
    public abstract class UInt32PlgxObject : PlgxObject
    {
        protected uint Data { get; }

        internal UInt32PlgxObject(byte[] data)
        {
            this.Data = ConvertToUInt(data);
        }

        private static uint ConvertToUInt(byte[] data)
        {
            // From KeePass MemUtils.BytesToUInt32

            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if (data.Length != 4)
            {
                throw new ArgumentOutOfRangeException("data");
            }

            return ((uint)data[0] | ((uint)data[1] << 8) | ((uint)data[2] << 16) |
                ((uint)data[3] << 24));
        }


        public override string ToString()
        {
            return string.Concat(base.GetPlgxObjectName(), ": ", this.Data);
        }
    }
}
