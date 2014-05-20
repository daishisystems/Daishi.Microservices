namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class Level3 : Level {
        public override SerialisableProperties GetSerializableProperties() {
            var serialisableProperties = base.GetSerializableProperties();
            serialisableProperties.ObjectName = "level3";

            return serialisableProperties;
        }
    }
}