namespace Daishi.Microservices.Components.Serialisation {
    public class StandardJsonParser : JsonParser {
        public override void FindProperty(JsonPropertyFinder finder, string propertyName) {
            finder.Find(propertyName);
        }

        public override void BuildObject(JsonObjectBuilder builder, string propertyName) {
            Json = string.Concat(propertyName, ":", builder.Build(JsonObjectType.Object));
        }
    }
}