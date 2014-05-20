#region Includes

using System.IO;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class StandardJsonSerialisor : JsonSerialisor {
        public StandardJsonSerialisor(BinaryWriter writer) : base(writer) {}

        public override void WriteStart() {
            writer.Write((byte) 123);
        }

        public override void Serialise(Serialisor serialisor) {
            const byte comma = 44, bracket = 125;

            writer.Write(serialisor.Serialise(true));
            var innerSerialisors = serialisor.InnerSerialisors;

            if (innerSerialisors != null) {
                writer.Write(comma);
                var serialisors = innerSerialisors.ToList();

                for (var i = 0; i < serialisors.Count; i++) {
                    var s = serialisors[i];
                    Serialise(s);

                    var isLastItem = i.Equals(serialisors.Count - 1);
                    writer.Write(!isLastItem ? comma : bracket);
                }
            }
            else if (serialisor is PropertiesSerialisor)
                writer.Write(bracket);
        }

        public override void WriteEnd(bool isNamed) {
            if (isNamed)
                writer.Write((byte) 125);
            writer.Flush();
            SerialisedObject = ((MemoryStream) writer.BaseStream).ToArray();
        }
    }
}