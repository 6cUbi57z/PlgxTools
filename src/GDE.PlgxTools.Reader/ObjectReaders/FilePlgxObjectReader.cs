using System;
using System.Collections.Generic;
using System.IO;
using GDE.PlgxTools.RawPlgxObjects;
using GDE.PlgxTools.RawPlgxObjects.FileObjects;
using GDE.PlgxTools.RawPlgxObjects.Primitive;

namespace GDE.PlgxTools.Reader.ObjectReaders
{
    public class FilePlgxObjectReader : PlgxObjectReader, IDisposable
    {
        private MemoryStream memoryStream;

        public FilePlgxObjectReader(FilePlgxObject fileObject) : base()
        {
            this.memoryStream = new MemoryStream(fileObject.Data);
            this.BinaryReader = new BinaryReader(this.memoryStream);
        }

        public override PlgxObject ReadNextObject()
        {
            KeyValuePair<ushort, byte[]>? rawPlgxObject = this.ReadPlgxObjectFromStream();

            if (!rawPlgxObject.HasValue)
            {
                return null;
            }

            byte[] data = rawPlgxObject.Value.Value;

            // Deterime the object type.
            switch (rawPlgxObject.Value.Key)
            {
                case (ushort)PlgxFileObjectType.EOF:
                    this.endOfStream = true;
                    return null;

                case (ushort)PlgxFileObjectType.Path:
                    return new FilePathPlgxObject(data);

                //case (ushort)PlgxFileObjectType.Data:
                //    throw new NotImplementedException();

                default:
                    return new RawPlgxObject(data);
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
                    this.BinaryReader.Dispose();
                    this.BinaryReader = null;

                    this.memoryStream.Dispose();
                    this.memoryStream = null;
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
