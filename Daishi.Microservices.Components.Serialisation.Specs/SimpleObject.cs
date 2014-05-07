#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class SimpleObject : IHaveSerialisableProperties {
        public string Name { get; set; }
        public int Count { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties("simpleObject", new List<Property> {
                new Property {
                    Key = "name",
                    Value = Name
                },
                new Property {
                    Key = "count",
                    Value = Count
                }
            });
        }
    }
}