namespace Daishi.Microservices.Components.Serialisation {
    public abstract class Deserialiser<T> {
        protected readonly SimpleJSONParser parser;

        protected Deserialiser(SimpleJSONParser parser) {
            this.parser = parser;
        }

        public abstract T Deserialise();
    }
}