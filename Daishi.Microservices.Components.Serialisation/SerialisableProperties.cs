#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class SerialisableProperties {
        public string ObjectName { get; private set; }
        public IEnumerable<Property> Properties { get; private set; }

        public SerialisableProperties(IEnumerable<Property> properties) {
            Properties = properties;
        }

        public SerialisableProperties(string objectName, IEnumerable<Property> properties) : this(properties) {
            ObjectName = objectName;
        }
    }
}