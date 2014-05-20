#region Includes

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class SimpleObjectContainingAnArrayPropertyWithoutObjectName : IHaveSerialisableProperties {
        public string[] Values { get; set; }

        public virtual SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties(new List<JsonProperty>(
                Values.Select(v => new StringJsonProperty {
                    Value = v
                })));
        }
    }
}