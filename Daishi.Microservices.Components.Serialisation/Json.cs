#region Includes

using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class Json {
        // todo: Name this something like Microservice-optimised serialisor
        public static void Parse(JsonParser parser, string data, string propertyName) {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            using (var reader = new BinaryReader(stream)) {
                parser.FindProperty(new JsonPropertyFinder(reader,
                    new WordBuilder(reader),
                    new JsonPropertyValidator(reader)), propertyName);
                parser.BuildObject(new JsonObjectBuilder(reader, new JsonContainerFactory(),
                    new JsonReader(reader)), propertyName);
            }
        }

        public static byte[] Serialise(Serialisor serialisor, SerialisableProperties serialisableProperties) {
            using (var writer = new BinaryWriter(new MemoryStream(), new UTF8Encoding(false))) {
                writer.Write((byte) 123);
                var hasProperties = false;

                if (serialisableProperties.Properties.Any()) {
                    writer.Write(serialisor.Serialise());
                    hasProperties = true;
                }

                if (!serialisableProperties.Serialisors.Any()) {
                    writer.Flush();
                    return ((MemoryStream) writer.BaseStream).ToArray();
                }

                if (hasProperties)
                    writer.Write((byte) 44);

                var serialisors = serialisableProperties.Serialisors.ToList();

                for (var i = 0; i < serialisors.Count; i++) {
                    var s = serialisors[i];
                    writer.Write(s.Serialise());

                    var isFinalItem = i.Equals(serialisors.Count - 1);
                    if (!isFinalItem)
                        writer.Write((byte) 44);
                }

                writer.Write((byte) 125);

                writer.Flush();
                return ((MemoryStream) writer.BaseStream).ToArray();
            }
        }
    }
}