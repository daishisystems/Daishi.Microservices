namespace Daishi.Microservices.Components.Serialisation {
    public class StandardJsonParser : JsonParser {
        public override void FindProperty(JsonPropertyFinder finder) {
            finder.Find("response");
        }

        public override void BuildObject(JsonObjectBuilder builder) {
            Json = string.Concat("response:", builder.Build(JsonObjectType.Object));
        }
    }
}