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
            if (hasSimpleProperties)
                writer.Write(comma);

            var serialisorList = serialisors.ToList();

            for (var i = 0; i < serialisorList.Count; i++) {
                var serialisor = serialisorList[i];
                writer.Write(serialisor.Serialise());

                var isFinalItem = i.Equals(serialisorList.Count - 1);
                if (!isFinalItem)
                    writer.Write(comma);

                if (serialisor.SerialisableProperties == null || serialisor.SerialisableProperties.Serialisors == null) continue;
                var children = serialisor.SerialisableProperties.Serialisors;
                if (children != null)
                    SerialiseComplexProperties(hasSimpleProperties, children);
            }
        }

        public override void WriteEnd() {
            writer.Write((byte) 125);
            writer.Flush();
            SerialisedObject = ((MemoryStream) writer.BaseStream).ToArray();
        }
    }
}