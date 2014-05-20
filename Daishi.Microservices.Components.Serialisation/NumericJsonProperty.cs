namespace Daishi.Microservices.Components.Serialisation {
    public class NumericJsonProperty : JsonProperty {
        public override string FormatValue() {
            return Value.ToString();
        }
    }
}