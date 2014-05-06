#region Includes

using System.IO;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class JsonPropertyFinder {
        private readonly BinaryReader _reader;
        private readonly WordBuilder _wordBuilder;

        public JsonPropertyFinder(BinaryReader reader, WordBuilder wordBuilder) {
            _reader = reader;
            _wordBuilder = wordBuilder;
        }

        public long Find(string target) {
            if (string.IsNullOrEmpty(target)) return -1L;

            var characterFinder = new CharacterFinder(_reader);
            var positions = characterFinder.Find(target[0]);

            if (positions.Select(position => new string(_wordBuilder
                .Build()
                .ToArray()))
                .Any(target.Equals)) {
                return _wordBuilder.Position;
            }
            return -1L;
        }
    }
}