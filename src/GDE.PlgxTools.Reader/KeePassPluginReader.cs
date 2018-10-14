using System;
using System.IO;
using GDE.PlgxTools.RawPlgxObjects;
using GDE.PlgxTools.Reader.ObjectReaders;

namespace GDE.PlgxTools.Reader
{
    public class KeePassPluginReader : IDisposable
    {
        private FileStream fileStream;
        private BinaryReader binaryReader;
        private RootPlgxObjectReader plgxObjectReader;

        public uint Signature1 { get; }
        public uint Signature2 { get; }
        public uint PlgxVersion { get; }

        public KeePassPluginReader(string pluginFile)
        {
            this.fileStream = new FileStream(pluginFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            this.binaryReader = new BinaryReader(this.fileStream);

            this.Signature1 = this.binaryReader.ReadUInt32();
            this.Signature2 = this.binaryReader.ReadUInt32();
            this.PlgxVersion = this.binaryReader.ReadUInt32();

            this.plgxObjectReader = new RootPlgxObjectReader(this.binaryReader);
        }

        public PlgxObject ReadNextObject()
        {
            return this.plgxObjectReader.ReadNextObject();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.binaryReader.Dispose();
                    this.binaryReader = null;

                    this.fileStream.Dispose();
                    this.fileStream = null;
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
