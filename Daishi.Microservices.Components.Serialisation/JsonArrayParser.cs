namespace Daishi.Microservices.Components.Serialisation {
    public class JsonArrayParser : JsonParser {
        public override string BuildObject(JsonObjectBuilder builder, string propertyName) {
            return string.Concat(propertyName, ":", builder.Build(JsonObjectType.Array));
        }
    }
}