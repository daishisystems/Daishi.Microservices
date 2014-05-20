namespace Daishi.Microservices.Components.Serialisation {
    public class StringJsonProperty : JsonProperty {
        public override string FormatValue() {
            return string.Concat("\"", Value, "\"");
        }
    }
}