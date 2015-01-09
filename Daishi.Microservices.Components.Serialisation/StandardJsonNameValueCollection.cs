#region Includes

using System.Collections.Specialized;
using System.IO;
using Newtonsoft.Json;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class StandardJsonNameValueCollection : JsonNameValueCollection {
        public StandardJsonNameValueCollection(string json) : base(json) {}

        public override NameValueCollection Parse() {
            var parsed = new NameValueCollection();

            using (var reader = new JsonTextReader(new StringReader(json))) {
                while (reader.Read()) {
                    if (reader.Value != null && !reader.TokenType.Equals(JsonToken.PropertyName))
                        parsed.Add(reader.Path, reader.Value.ToString());
                }

                return parsed;
            }
        }
    }
}