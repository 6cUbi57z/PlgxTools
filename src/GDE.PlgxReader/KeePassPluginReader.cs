using System;
using System.IO;
using GDE.PlgxReader.PlgxObjectReaders;
using GDE.PlgxReader.PlgxObjects;

namespace GDE.PlgxReader
{
    public class KeePassPluginReader : IDisposable
    {
        private FileStream fileStream;
        private BinaryReader binaryReader;
        private RootPlgxObjectReader plgxObjectReader;

        private uint uSig1;
        private uint uSig2;
        private uint uVersion;

        public KeePassPluginReader(string pluginFile)
        {
            this.fileStream = new FileStream(pluginFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            this.binaryReader = new BinaryReader(this.fileStream);

            this.uSig1 = this.binaryReader.ReadUInt32();
            this.uSig2 = this.binaryReader.ReadUInt32();
            this.uVersion = this.binaryReader.ReadUInt32();

            this.ValidateSigs();
            this.ValidateVersion();

            this.plgxObjectReader = new RootPlgxObjectReader(this.binaryReader);
        }

        private void ValidateSigs()
        {
            if (this.uSig1 != PlgxConstants.PlgxSignature1)
            {
                throw new IOException("Invalid uSig1.");
            }

            if (this.uSig2 != PlgxConstants.PlgxSignature2)
            {
                throw new IOException("Invalid uSig2.");
            }
        }

        private void ValidateVersion()
        {
            if ((uVersion & PlgxConstants.PlgxVersionMask) > (PlgxConstants.PlgxVersion & PlgxConstants.PlgxVersionMask))
            {
                throw new IOException("Invalid PLGX Version.");
            }
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
