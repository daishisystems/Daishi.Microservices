namespace Daishi.Microservices.Components.Serialisation {
    public abstract class Serialisor {
        protected bool encapsulate;
        public SerialisableProperties SerialisableProperties { get; protected set; }
        public abstract byte[] Serialise();
    }
}