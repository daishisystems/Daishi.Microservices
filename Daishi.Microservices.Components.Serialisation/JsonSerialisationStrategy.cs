#region Includes

using System;
using System.IO;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public abstract class JsonSerialisationStrategy : IDisposable {
        protected readonly BinaryWriter writer;
        public byte[] SerialisedObject { get; protected set; }

        protected JsonSerialisationStrategy(BinaryWriter writer) {
            this.writer = writer;
        }

        public abstract void WriteStart();
        public abstract void Serialise(JsonSerialisor serialisor);
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