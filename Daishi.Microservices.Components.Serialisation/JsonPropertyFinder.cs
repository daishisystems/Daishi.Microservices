#region Includes

using System.IO;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class JsonPropertyFinder {
        private readonly StreamReader _reader;

        public JsonPropertyFinder(StreamReader reader) {
            _reader = reader;
        }

        public long Find(string target) {
            var characterFinder = new CharacterFinder(_reader);
            var positions = characterFinder.Find(target[0]);

            foreach (var position in positions) {
                // Find the word.
            }

            return 1L;
        }
    }
}