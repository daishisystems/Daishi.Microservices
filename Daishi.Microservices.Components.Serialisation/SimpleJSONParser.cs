#region Includes

using System.Collections.Specialized;
using System.IO;
using Newtonsoft.Json;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class SimpleJSONParser {
        private readonly string _json;

        public SimpleJSONParser(string json) {
            _json = json;
        }

        public NameValueCollection Parse() {
            var parsed = new NameValueCollection();

            using (var reader = new JsonTextReader(new StringReader(_json))) {
                while (reader.Read()) {
                    if (reader.Value != null && !reader.TokenType.Equals(JsonToken.PropertyName))
                        parsed.Add(reader.Path, reader.Value.ToString());
                }

                return parsed;
            }
        }
    }
}