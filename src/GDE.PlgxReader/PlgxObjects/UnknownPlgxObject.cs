namespace GDE.PlgxReader.PlgxObjects
{
    public class UnknownPlgxObject : PlgxObject
    {
        internal UnknownPlgxObject(byte[] data)
        {
            this.Data = data;
        }

        public byte[] Data { get; }
    }
}
