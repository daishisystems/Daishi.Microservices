#region Includes

using System.Collections.Generic;
using System.Globalization;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class ComplexObject : IHaveSerialisableProperties {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ComplexArrayObject> ComplexArrayObjects { get; set; }
        public List<double> Doubles { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties("complexObject", new List<JsonProperty> {
                new StringJsonProperty {
                    Key = "name",
                    Value = Name
                },
                new StringJsonProperty {
                    Key = "description",
                    Value = Description
                }
            }, new List<JsonSerialisor> {
                new ComplexJsonArraySerialisor("complexArrayObjects",
                    ComplexArrayObjects.Select(c => c.GetSerializableProperties())),
                new JsonArraySerialisor("doubles",
                    Doubles.Select(d => d.ToString(CultureInfo.InvariantCulture)), JsonPropertyType.Numeric)
            });
        }
    }
}