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
            return new SerialisableProperties("complexObject", new List<Property> {
                new StringProperty {
                    Key = "name",
                    Value = Name
                },
                new StringProperty {
                    Key = "description",
                    Value = Description
                }
            }, new List<Serialisor> {
                new ComplexArraySerialisor("complexArrayObjects",
                    ComplexArrayObjects.Select(c => c.GetSerializableProperties())),
                new ArraySerialisor("doubles",
                    Doubles.Select(d => d.ToString(CultureInfo.InvariantCulture)), JsonPropertyType.Numeric)
            });
        }
    }
}