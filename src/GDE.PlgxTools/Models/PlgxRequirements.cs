namespace GDE.PlgxReader.Models
{
    public class PlgxRequirements
    {
        public ulong? KeePassVersion { get; set; }

        public ulong? DotNetVersion { get; set; }

        public OperatingSystem OS { get; set; }

        public uint? PointerSize { get; set; }

        public enum OperatingSystem
        {
            Any = 0,
            Windows = 1,
            Linux = 2,
            Mac = 3
        }
    }
}