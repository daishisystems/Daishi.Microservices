#region Includes

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class ComplexArrayObjectContainer : IHaveSerialisableProperties {
        public string Name { get; set; }
        public List<ComplexArrayObject> ComplexArrayObjects { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties(new List<JsonProperty> {
                new StringJsonProperty {
                    Key = "name",
                    Value = Name
                }
            }, new List<JsonSerialisor> {
                new ComplexJsonArraySerialisor("arrayOfComplexObjects",
                    ComplexArrayObjects.Select(c => c.GetSerializableProperties()))
            });
        }
    }
}