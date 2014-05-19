#region Includes

using System.Collections.Generic;
using System.IO;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class Json {
        public static void Parse(JsonParser parser, string data, string propertyName) {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            using (var reader = new BinaryReader(stream)) {
                parser.FindProperty(new JsonPropertyFinder(new CharacterFinder(reader),
                    new WordBuilder(reader),
                    new JsonPropertyValidator(reader)), propertyName);
                parser.BuildObject(new JsonObjectBuilder(reader, new JsonContainerFactory(),
                    new JsonReader(reader)), propertyName);
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