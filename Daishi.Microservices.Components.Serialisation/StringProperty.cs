namespace Daishi.Microservices.Components.Serialisation {
    public class StringProperty : Property {
        public override string FormatValue() {
            return string.Concat("\"", Value, "\"");
        }
    }
}