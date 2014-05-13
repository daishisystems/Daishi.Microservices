namespace Daishi.Microservices.Components.Serialisation {
    public abstract class Serialisor {
        protected readonly SerialisableProperties serialisableProperties;

        protected Serialisor() {}

        protected Serialisor(SerialisableProperties serialisableProperties) {
            this.serialisableProperties = serialisableProperties;
        }

        public abstract byte[] Serialise();
    }
}