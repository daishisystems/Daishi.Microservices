#region Includes

using System.IO;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    internal static class DeepSerialisor {
        public static void Serialise(Serialisor serialisor, BinaryWriter writer) {
            const byte comma = 44, bracket = 125;

            writer.Write(serialisor.Serialise(true));
            var innerSerialisors = serialisor.InnerSerialisors;

            if (innerSerialisors != null) {
                writer.Write(comma);
                var serialisors = innerSerialisors.ToList();

                for (var i = 0; i < serialisors.Count; i++) {
                    var s = serialisors[i];
                    Serialise(s, writer);

                    var isLastItem = i.Equals(serialisors.Count - 1);
                    writer.Write(!isLastItem ? comma : bracket);
                }
            }
            else if (serialisor is PropertiesSerialisor)
                writer.Write(bracket);
        }
    }
}