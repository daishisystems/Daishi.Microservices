#region Includes

using System;
using System.Collections.Generic;
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
        public abstract bool SerialiseSimpleProperties(Serialisor serialisor);
        public abstract void SerialiseComplexProperties(bool hasSimpleProperties, IEnumerable<Serialisor> serialisors );
        public abstract void WriteEnd();

        void IDisposable.Dispose() {
            Close();
        }

        public virtual void Close() {
            if (writer != null)
                writer.Dispose();
        }
    }
}