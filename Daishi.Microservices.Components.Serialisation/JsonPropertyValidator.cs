#region Includes

using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class JsonPropertyValidator {
        private readonly BinaryReader _reader;

        public JsonPropertyValidator(BinaryReader binaryReader) {
            _reader = binaryReader;
        }

        public bool Validate() {
            return !GetBytesUntilNextSemiColon()
                .Any(@byte => !@byte.Equals(32) || !@byte.Equals(34));
        }

        private IEnumerable<long> GetBytesUntilNextSemiColon() {
            var current = _reader.Read();
            while (current > -1 && !current.Equals(58))
                yield return current;
        }
    }
}