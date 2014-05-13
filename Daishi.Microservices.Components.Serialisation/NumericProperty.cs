namespace Daishi.Microservices.Components.Serialisation {
    public class NumericProperty : Property {
        public override string FormatValue() {
            return Value.ToString();
        }
    }
}