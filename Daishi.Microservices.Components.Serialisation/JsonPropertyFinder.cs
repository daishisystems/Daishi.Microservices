#region Includes

using System.IO;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class JsonPropertyFinder {
        private readonly BinaryReader _reader;
        private readonly WordBuilder _builder;
        private readonly JsonPropertyValidator _validator;

        public JsonPropertyFinder(BinaryReader reader, WordBuilder builder, JsonPropertyValidator validator) {
            _reader = reader;
            _builder = builder;
            _validator = validator;
        }

        public long Find(string target) {
            if (string.IsNullOrEmpty(target)) return -1L;

            var characterFinder = new CharacterFinder(_reader);
            var positions = characterFinder.Find(target[0]);

            if (positions.Select(position => new string(_builder.Build().ToArray()))
                .Where(word => target.Equals(word))
                .Any(word => _validator.Validate())) {
                return _builder.ResetPosition;
            }

            return -1L;
        }
    }
}