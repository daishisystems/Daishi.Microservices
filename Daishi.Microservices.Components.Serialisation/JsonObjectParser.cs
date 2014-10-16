namespace Daishi.Microservices.Components.Serialisation {
    public class JsonObjectParser : JsonParser {
        public override string BuildObject(JsonObjectBuilder builder, string propertyName) {
            return string.Concat(propertyName, ":", builder.Build(JsonObjectType.Object));
        }
    }
}