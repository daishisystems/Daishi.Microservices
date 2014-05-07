#region Includes

using System.Collections.Generic;
using System.IO;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class JsonReader {
        private readonly BinaryReader _reader;

        public JsonReader(BinaryReader reader) {
            _reader = reader;
        }

        public IEnumerable<char> ReadToValue(char @value) {
            int current;
            char character;

            do {
                current = _reader.Read();
                character = (char) current;

                yield return character;
            } while (current > -1 && !character.Equals(@value));
        }
    }
}