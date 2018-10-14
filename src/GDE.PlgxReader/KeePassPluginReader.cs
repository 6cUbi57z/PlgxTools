using System;
using System.IO;
using GDE.PlgxReader.PlgxObjects;

namespace GDE.PlgxReader
{
    public class KeePassPluginReader : IDisposable
    {
        private FileStream fileStream;
        private BinaryReader reader;

        private uint uSig1;
        private uint uSig2;
        private uint uVersion;
        private bool endOfFile;

        public KeePassPluginReader(string pluginFile)
        {
            this.fileStream = new FileStream(pluginFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            this.reader = new BinaryReader(this.fileStream);

            this.uSig1 = this.reader.ReadUInt32();
            this.uSig2 = this.reader.ReadUInt32();
            this.uVersion = this.reader.ReadUInt32();

            this.ValidateSigs();
            this.ValidateVersion();
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
            // If we already at the end of the file, return null.
            if (this.endOfFile)
            {
                return null;
            }

            // Read the object data
            ushort objectTypeRaw = this.reader.ReadUInt16();
            uint length = this.reader.ReadUInt32();
            byte[] data = (length > 0) ? this.reader.ReadBytes((int)length) : null;

            // Deterime the object type.
            switch (objectTypeRaw)
            {
                case (ushort)PlgxObjectType.EOF:
                    this.endOfFile = true;
                    return null;

                //case (ushort)PlgxObjectType.FileUuid:
                //    throw new NotImplementedException();

                case (ushort)PlgxObjectType.BaseFileName:
                    return new BaseFileNamePlgxObject(data);

                case (ushort)PlgxObjectType.CreationTime:
                    return new CreationTimePlgxObject(data);

                case (ushort)PlgxObjectType.GeneratorName:
                    return new GeneratorNamePlgxObject(data);

                //case (ushort)PlgxObjectType.GeneratorVersion:
                //    throw new NotImplementedException();

                //case (ushort)PlgxObjectType.PrereqKP:
                //    throw new NotImplementedException();

                //case (ushort)PlgxObjectType.PrereqNet:
                //    throw new NotImplementedException();

                case (ushort)PlgxObjectType.PrereqOS:
                    return new OperatingSystemRequirementPlgxObject(data);

                //case (ushort)PlgxObjectType.PrereqPtr:
                //    throw new NotImplementedException();

                case (ushort)PlgxObjectType.BuildPre:
                    return new PreBuildPlgxObject(data);

                case (ushort)PlgxObjectType.BuildPost:
                    return new PostBuildPlgxObject(data);

                case (ushort)PlgxObjectType.BeginContent:
                    return new BeginContentPlgxObject();

                //case (ushort)PlgxObjectType.File:
                //    throw new NotImplementedException();

                case (ushort)PlgxObjectType.EndContent:
                    return new EndContentPlgxObject();

                default:
                    return new UnknownPlgxObject(data);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.reader.Dispose();
                    this.reader = null;

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
