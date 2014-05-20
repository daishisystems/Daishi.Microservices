#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class Level : IHaveSerialisableProperties {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }

        public virtual SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties(new List<Property> {
                new StringProperty {
                    Key = "name",
                    Value = Name
                },
                new StringProperty {
                    Key = "description",
                    Value = Description
                },
                new NumericProperty {
                    Key = "count",
                    Value = Count
                }
            });
        }
    }
}