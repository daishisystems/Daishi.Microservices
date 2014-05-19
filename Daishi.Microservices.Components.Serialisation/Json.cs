#region Includes

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class Json {
        public static void Parse(JsonParser parser, string data, string propertyName, bool returnFirst = false) {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            using (var reader = new BinaryReader(stream)) {
                var properties = parser.FindProperty(new JsonPropertyFinder(new CharacterFinder(reader),
                    new WordBuilder(reader),
                    new JsonPropertyValidator(reader)), propertyName);

                var objects = properties.Select(property => parser.BuildObject(
                    new JsonObjectBuilder(reader, new JsonContainerFactory(), new JsonReader(reader)),
                    propertyName)).ToList();

                parser.Objects = objects;
            }
        }

        public static void Serialise(JsonSerialisor jsonSerialisor, Serialisor serialisor, IEnumerable<Serialisor> serialisors) {
            jsonSerialisor.WriteStart();
            var hasSimpleProperties = jsonSerialisor.SerialiseSimpleProperties(serialisor);
            jsonSerialisor.SerialiseComplexProperties(hasSimpleProperties, serialisors);
            jsonSerialisor.WriteEnd();
        }
    }
}