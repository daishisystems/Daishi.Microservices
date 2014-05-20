#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class ComplexArrayObject : IHaveSerialisableProperties {
        public string Name { get; set; }
        public string Description { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties("complexArrayObject", new List<JsonProperty> {
                new StringJsonProperty {
                    Key = "name",
                    Value = Name
                },
                new StringJsonProperty {
                    Key = "description",
                    Value = Description
                }
            });
        }
    }
}