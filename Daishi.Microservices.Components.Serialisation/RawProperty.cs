namespace Daishi.Microservices.Components.Serialisation {
    public class RawProperty : Property {
        public override string FormatValue() {
            return string.Concat(Value);
        }
    }
}