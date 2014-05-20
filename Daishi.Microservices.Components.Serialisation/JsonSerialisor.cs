#region Includes

using System;
using System.IO;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public abstract class JsonSerialisor : IDisposable {
        protected readonly BinaryWriter writer;
        public byte[] SerialisedObject { get; set; }

        protected JsonSerialisor(BinaryWriter writer) {
            this.writer = writer;
        }

        public abstract void WriteStart();
        public abstract void Serialise(Serialisor serialisor);
        public abstract void WriteEnd(bool isNamed);

        void IDisposable.Dispose() {
            Close();
        }

        public virtual void Close() {
            if (writer != null)
                writer.Dispose();
        }
    }
}