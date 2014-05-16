#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class ComplexArrayObject : IHaveSerialisableProperties {
        public string Name { get; set; }
        public string Description { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties("complexArrayObject", new List<Property> {
                new StringProperty {
                    Key = "name",
                    Value = Name
                },
                new StringProperty {
                    Key = "description",
                    Value = Description
                }
            });
        }
    }
}