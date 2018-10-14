namespace GDE.PlgxTools.RawPlgxObjects.Primitive
{
    public class RawPlgxObject : PlgxObject
    {
        public RawPlgxObject(byte[] data)
        {
            this.Data = data;
        }

        public byte[] Data { get; }
    }
}
