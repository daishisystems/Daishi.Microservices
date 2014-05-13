#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class SimpleObjectWithoutName : SimpleObject {
        public override SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties(new List<Property> {
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