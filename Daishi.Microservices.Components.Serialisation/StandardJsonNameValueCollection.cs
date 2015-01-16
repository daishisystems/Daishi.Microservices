#region Includes

using System.Collections.Specialized;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class StandardJsonNameValueCollection : JsonNameValueCollection {
        public StandardJsonNameValueCollection(string json) : base(json) {}

        public override NameValueCollection Parse(bool mergeArrayValues = false) {
            var parsed = new NameValueCollection();
            var regex = mergeArrayValues ? new Regex(@"\[\d+]") : null;

            using (var reader = new JsonTextReader(new StringReader(json))) {
                while (reader.Read()) {
                    if (reader.Value == null || reader.TokenType.Equals(JsonToken.PropertyName)) continue;

                    if (mergeArrayValues) {
                        var match = regex.Match(reader.Path);
                        parsed.Add(match.Success ? reader.Path.Replace(match.Value, string.Empty) : reader.Path, reader.Value.ToString());
                    }
                    else
                        parsed.Add(reader.Path, reader.Value.ToString());
                }

                return parsed;
            }
        }
    }
}