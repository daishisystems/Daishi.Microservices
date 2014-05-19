#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class StandardJsonParser : JsonParser {
        public override IEnumerable<long> FindProperty(JsonPropertyFinder finder, string propertyName) {
            return finder.Find(propertyName);
        }

        public override string BuildObject(JsonObjectBuilder builder, string propertyName) {
            return string.Concat(propertyName, ":", builder.Build(JsonObjectType.Object));
        }
    }
}