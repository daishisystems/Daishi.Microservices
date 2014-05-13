namespace Daishi.Microservices.Components.Serialisation {
    public abstract class JsonParser {
        public string Json { get; protected set; }

        public abstract void FindProperty(JsonPropertyFinder finder, string propertyName);
        public abstract void BuildObject(JsonObjectBuilder builder, string propertyName);
    }
}