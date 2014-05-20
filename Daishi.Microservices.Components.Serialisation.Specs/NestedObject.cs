#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class NestedObject : IHaveSerialisableProperties {
        public string Name { get; set; }
        public Level1 Level1 { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties(new List<JsonProperty> {
                new StringJsonProperty {
                    Key = "name",
                    Value = Name
                }
            }, new List<JsonSerialisor> {
                new JsonPropertiesSerialisor(Level1.GetSerializableProperties())
            });
        }
    }
}