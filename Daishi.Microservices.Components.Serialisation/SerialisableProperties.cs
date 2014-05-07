#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class SerialisableProperties {
        public string ObjectName { get; private set; }
        public IEnumerable<Property> Properties { get; private set; }

        public SerialisableProperties(string objectName, IEnumerable<Property> properties) {
            ObjectName = objectName;
            Properties = properties;
        }
    }
}