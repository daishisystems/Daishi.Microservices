#region Includes

using System.IO;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class JsonPropertyFinder {
        private readonly BinaryReader _reader;

        public JsonPropertyFinder(BinaryReader reader) {
            _reader = reader;
        }

        public long Find(string target) {
            var characterFinder = new CharacterFinder(_reader);
            var positions = characterFinder.Find(target[0]);

            var wordBuilder = new WordBuilder(_reader); // todo: Inject

            foreach (var position in positions) {
                var word = new string(wordBuilder.Build().ToArray());
                if (target.Equals(word))
                    return wordBuilder.Position;
            }

            return -1L;
        }
    }
}