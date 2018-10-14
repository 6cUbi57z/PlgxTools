using System.IO;
using GDE.PlgxReader.PlgxObjectReaders;
using GDE.PlgxReader.PlgxObjects.FileObjects;

namespace GDE.PlgxReader.PlgxObjects
{
    public class FilePlgxObject : PlgxObject
    {
        internal FilePlgxObject(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data, false))
            using (BinaryReader reader = new BinaryReader(ms))
            {
                FilePlgxObjectReader plgxObjectReader = new FilePlgxObjectReader(reader);

                PlgxObject plgxObject;
                while ((plgxObject = plgxObjectReader.ReadNextObject()) != null)
                {
                    if (plgxObject is PathPlgxFileObject)
                    {
                        this.FilePath = ((PathPlgxFileObject)plgxObject).FilePath;
                    }
                }
            }
        }

        public string FilePath { get; }

        public override string ToString()
        {
            return string.Concat(this.GetPlgxObjectName(), ": ", this.FilePath);
        }
    }
}
