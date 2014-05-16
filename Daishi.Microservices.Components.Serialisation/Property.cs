namespace Daishi.Microservices.Components.Serialisation {
    public abstract class Property {
        public string Key { get; set; }
        public object Value { get; set; }       
        public abstract string FormatValue();

        public override string ToString() {
            return FormatValue();
        }
    }
}