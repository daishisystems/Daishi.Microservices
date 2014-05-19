#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public abstract class JsonParser {
        public IEnumerable<string> Objects { get; set; }

        public abstract IEnumerable<long> FindProperty(JsonPropertyFinder finder, string propertyName);
        public abstract string BuildObject(JsonObjectBuilder builder, string propertyName);
    }
}