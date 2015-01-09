namespace Daishi.Microservices.Components.Serialisation {
    public abstract class Deserialiser<T> {
        protected readonly JsonNameValueCollection jsonNameValueCollection;

        protected Deserialiser(JsonNameValueCollection jsonNameValueCollection) {
            this.jsonNameValueCollection = jsonNameValueCollection;
        }

        public abstract T Deserialise();
    }
}