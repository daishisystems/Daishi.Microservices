#region Includes

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class JsonPropertyFinder {
        private readonly CharacterFinder _finder;
        private readonly WordBuilder _builder;
        private readonly JsonPropertyValidator _validator;

        public JsonPropertyFinder(CharacterFinder finder, WordBuilder builder, JsonPropertyValidator validator) {
            _finder = finder;
            _builder = builder;
            _validator = validator;
        }

        public IEnumerable<long> Find(string target) {
            if (string.IsNullOrEmpty(target))
                yield break;

            var positions = _finder.Find(target[0]);

            foreach (var position in positions) {
                var nextCharacters = _builder.Build();
                var word = nextCharacters.Aggregate(string.Empty,
                    (current, nextCharacter) => current + nextCharacter);

                if (!target.Equals(word)) continue;
                var isValid = _validator.Validate();

                if (isValid)
                    yield return _builder.CurrentPosition;
            }
        }
    }
}