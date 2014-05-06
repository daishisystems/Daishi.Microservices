#region Includes

using System.Collections.Generic;
using System.IO;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class WordBuilder {
        private readonly BinaryReader _reader;

        public long Position { get; private set; }

        public WordBuilder(BinaryReader reader) {
            _reader = reader;
        }

        public IEnumerable<char> Build() {
            var stream = _reader.BaseStream;
            stream.Position--;

            int current;
            var endOfWord = false;

            do {
                current = _reader.Read();
                var character = (char) current;

                if (char.IsLetterOrDigit(character))
                    yield return character;
                else
                    endOfWord = true;
            } while (current > -1 && !endOfWord);

            Position = stream.Position;
        }
    }
}