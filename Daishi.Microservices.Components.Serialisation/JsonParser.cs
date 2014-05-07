namespace Daishi.Microservices.Components.Serialisation {
    public abstract class JsonParser {
        public string Json { get; protected set; }

        public abstract void FindProperty(JsonPropertyFinder finder);
        public abstract void BuildObject(JsonObjectBuilder builder);
    }
}