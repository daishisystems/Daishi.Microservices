#region Includes

using System.Collections.Generic;
using System.IO;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class CharacterFinder {
        private readonly Stream _stream;

        public CharacterFinder(Stream stream) {
            _stream = stream;
        }

        public IEnumerable<long> Find(char target) {
            using (var reader = new StreamReader(_stream)) {
                int current;
                do {
                    current = reader.Read();
                    var character = (char) current;

                    if (character.Equals(target))
                        yield return current;
                } while (current > -1);
            }
        }
    }
}