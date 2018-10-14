namespace GDE.PlgxReader.PlgxObjects
{
    internal enum PlgxObjectType : ushort
    {
        EOF = 0,
        FileUuid = 1,
        BaseFileName = 2,
        BeginContent = 3,
        File = 4,
        EndContent = 5,
        CreationTime = 6,
        GeneratorName = 7,
        GeneratorVersion = 8,
        PrereqKP = 9, // KeePass version
        PrereqNet = 10, // .NET Framework version
        PrereqOS = 11, // Operating system
        PrereqPtr = 12, // Pointer size
        BuildPre = 13,
        BuildPost = 14
    }
}
