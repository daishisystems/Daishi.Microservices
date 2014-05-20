#region Includes

using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class StandardJsonSerialisor : JsonSerialisor {
        private const byte comma = 44;
        public StandardJsonSerialisor(BinaryWriter writer) : base(writer) {}

        public override void WriteStart() {
            writer.Write((byte) 123);
        }

        public override bool SerialiseSimpleProperties(Serialisor serialisor) {
            var serialisedSimpleProperties = serialisor.Serialise();
            writer.Write(serialisedSimpleProperties);
            return serialisedSimpleProperties.Any();
        }

        public override void SerialiseComplexProperties(bool hasSimpleProperties, IEnumerable<Serialisor> serialisors) {
            if (serialisors == null) return;

            var serialisorList = serialisors.ToList();
            if (!serialisorList.Any()) return;

            if (hasSimpleProperties)
                writer.Write(comma);

            for (var i = 0; i < serialisorList.Count; i++) {
                var serialisor = serialisorList[i];
                DeepSerialisor.Serialise(serialisor, writer);

                var isFinalItem = i.Equals(serialisorList.Count - 1);
                if (!isFinalItem)
                    writer.Write(comma);
            }
        }

        public override void WriteEnd() {
            writer.Write((byte) 125);
            writer.Flush();
            SerialisedObject = ((MemoryStream) writer.BaseStream).ToArray();
        }
    }
}