#region Includes

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class SimpleObjectContainingAnArrayPropertyWithoutObjectName : IHaveSerialisableProperties {
        public string[] Values { get; set; }

        public virtual SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties(new List<Property>(
                Values.Select(v => new StringProperty {
                    Value = v
                })));
        }
    }
}