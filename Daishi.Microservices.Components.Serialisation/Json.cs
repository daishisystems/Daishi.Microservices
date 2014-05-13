#region Includes

using System;
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
            var metadata = serialisableProperties.Properties.Any()
                ? serialisor.Serialise() : new byte[0];

            if (!serialisableProperties.Serialisors.Any())
                return metadata;
            
            var total = serialisableProperties.Serialisors.Select(s => s.Serialise()).ToList();
            var final = new byte[metadata.Length + total.Sum(t => t.Length)];

            var offset = 0;
            foreach (var bytes in total) {
                Buffer.BlockCopy(bytes, 0, final, offset, bytes.Length);
                offset += bytes.Length;
            }

            return final;
        }
    }
}