#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class SerialisableProperties {
        public string ObjectName { get; set; }
        public IEnumerable<JsonProperty> Properties { get; private set; }
        public IEnumerable<JsonSerialisor> Serialisors { get; set; }

        public SerialisableProperties(IEnumerable<JsonProperty> properties) {
            Properties = properties;
        }

        public SerialisableProperties(IEnumerable<JsonSerialisor> serialisors) {
            Serialisors = serialisors;
        }

        public SerialisableProperties(string objectName,
            IEnumerable<JsonProperty> properties) : this(properties) {
            ObjectName = objectName;
        }

        public SerialisableProperties(string objectName,
            IEnumerable<JsonSerialisor> serialisors) : this(serialisors) {
            ObjectName = objectName;
        }

        public SerialisableProperties(IEnumerable<JsonProperty> properties,
            IEnumerable<JsonSerialisor> serialisors) : this(properties) {
            Serialisors = serialisors;
        }

        public SerialisableProperties(string objectName,
            IEnumerable<JsonProperty> properties, IEnumerable<JsonSerialisor> serialisors)
            : this(properties, serialisors) {
            ObjectName = objectName;
        }
    }
}