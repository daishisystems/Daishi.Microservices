#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class SimpleObject : IHaveSerialisableProperties {
        public string Name { get; set; }
        public int Count { get; set; }

        public virtual SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties("simpleObject", new List<JsonProperty> {
                new StringJsonProperty {
                    Key = "name",
                    Value = Name
                },
                new NumericJsonProperty {
                    Key = "count",
                    Value = Count
                }
            });
        }
    }
}