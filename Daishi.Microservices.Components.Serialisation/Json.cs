#region Includes

using System.IO;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class Json {
        public static void Parse(JsonParser parser, string data) {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            using (var reader = new BinaryReader(stream)) {
                parser.FindProperty(new JsonPropertyFinder(reader,
                    new WordBuilder(reader),
                    new JsonPropertyValidator(reader)));
                parser.BuildObject(new JsonObjectBuilder(reader, new JsonContainerFactory(), new JsonReader(reader)));
            }
        }
    }
}