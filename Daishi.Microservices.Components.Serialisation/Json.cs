#region Includes

using System.IO;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public static class Json {
        public static void Parse(JsonParser parser, Stream data, string propertyName) {
            using (var reader = new BinaryReader(data)) {
                var properties = parser.FindProperty(new JsonPropertyFinder(new CharacterFinder(reader),
                    new WordBuilder(reader),
                    new JsonPropertyValidator(reader)), propertyName);

                var objects = properties.Select(property => parser.BuildObject(
                    new JsonObjectBuilder(reader, new JsonContainerFactory(), new JsonReader(reader)),
                    propertyName)).ToList();

                parser.Objects = objects;
            }
        }

        public static void Serialise(JsonSerialisationStrategy strategy, JsonSerialisor serialisor) {
            strategy.WriteStart();
            strategy.Serialise(serialisor);
            strategy.WriteEnd(serialisor.IsNamed);
        }

        public static T Deserialise<T>(Deserialiser<T> deserialiser, bool mergeArrayValues = false) {
            return deserialiser.Deserialise(mergeArrayValues);
        }
    }
}