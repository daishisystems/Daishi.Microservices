#region Includes

using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class JsonObjectBuilder {
        private readonly BinaryReader _binaryReader;
        private readonly JsonContainerFactory _factory;
        private readonly JsonReader _jsonReader;

        public JsonObjectBuilder(BinaryReader binaryReader, JsonContainerFactory factory, JsonReader jsonReader) {
            _binaryReader = binaryReader;
            _factory = factory;
            _jsonReader = jsonReader;
        }

        public string Build(JsonObjectType jsonObjectType) {
            char startContainer, endContainer;
            _factory.Parse(jsonObjectType, out startContainer, out endContainer);

            int startContainerCount = 1, endContainerCount = 0;
            int current;

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(_jsonReader.ReadToValue(startContainer).ToArray());

            do {
                current = _binaryReader.Read();
                var character = (char) current;

                if (character.Equals(startContainer))
                    startContainerCount++;
                else if (character.Equals(endContainer))
                    endContainerCount++;

                stringBuilder.Append(character);
            } while (current > -1 && !endContainerCount.Equals(startContainerCount));

            return !endContainerCount.Equals(startContainerCount) ?
                string.Concat(startContainer, endContainer) : stringBuilder.ToString();
        }
    }
}