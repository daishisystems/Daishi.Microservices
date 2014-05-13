#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class SimpleObject : IHaveSerialisableProperties {
        public string Name { get; set; }
        public int Count { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties("simpleObject", new List<Property> {
                new StringProperty {
                    Key = "name",
                    Value = Name
                },
                new NumericProperty {
                    Key = "count",
                    Value = Count
                }
            });
        }
    }
}