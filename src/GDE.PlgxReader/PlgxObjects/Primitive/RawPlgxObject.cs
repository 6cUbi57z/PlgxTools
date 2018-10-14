namespace GDE.PlgxReader.PlgxObjects.Primitive
{
    public class RawPlgxObject : PlgxObject
    {
        internal RawPlgxObject(byte[] data)
        {
            this.Data = data;
        }

        public byte[] Data { get; }
    }
}
