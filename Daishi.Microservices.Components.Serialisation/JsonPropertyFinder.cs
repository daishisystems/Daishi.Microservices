#region Includes

using System.IO;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class JsonPropertyFinder {
        private readonly Stream _stream;

        public JsonPropertyFinder(Stream stream) {
            _stream = stream;
        }

        public long Find(string target) {
            using (var reader = new StreamReader(_stream)) {
                // todo: Need character finder component
            }

            return 1L;
        }
    }
}