#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class SerialisableProperties {
        public string ObjectName { get; set; }
        public IEnumerable<Property> Properties { get; private set; }
        public IEnumerable<Serialisor> Serialisors { get; set; }

        public SerialisableProperties(IEnumerable<Property> properties) {
            Properties = properties;
        }

        public SerialisableProperties(IEnumerable<Serialisor> serialisors) {
            Serialisors = serialisors;
        }

        public SerialisableProperties(string objectName,
            IEnumerable<Property> properties) : this(properties) {
            ObjectName = objectName;
        }

        public SerialisableProperties(string objectName,
            IEnumerable<Serialisor> serialisors) : this(serialisors) {
            ObjectName = objectName;
        }

        public SerialisableProperties(IEnumerable<Property> properties,
            IEnumerable<Serialisor> serialisors) : this(properties) {
            Serialisors = serialisors;
        }

        public SerialisableProperties(string objectName,
            IEnumerable<Property> properties, IEnumerable<Serialisor> serialisors)
            : this(properties, serialisors) {
            //ObjectName = objectName;
        }
    }
}