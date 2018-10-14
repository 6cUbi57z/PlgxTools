namespace GDE.PlgxReader
{
    internal static class PlgxConstants
    {
        internal const uint PlgxSignature1 = 0x65D90719;
        internal const uint PlgxSignature2 = 0x3DDD0503;
        internal const uint PlgxVersion = 0x00010000;
        internal const uint PlgxVersionMask = 0xFFFF0000;

        internal const ushort PlgxfEOF = 0;
        internal const ushort PlgxfPath = 1;
        internal const ushort PlgxfData = 2;
    }
}
