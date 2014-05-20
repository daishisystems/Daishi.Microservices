namespace Daishi.Microservices.Components.Serialisation {
    public class RawJsonProperty : JsonProperty {
        public override string FormatValue() {
            return string.Concat(Value);
        }
    }
}