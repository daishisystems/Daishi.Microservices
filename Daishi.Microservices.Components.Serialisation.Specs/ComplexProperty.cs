#region Includes

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    public class ComplexProperty : IHaveSerialisableProperties {

        public ComplexProperty() {
            ComplexProperties = new List<ComplexProperty>();
            SubProperties = new ComplexProperty[] {};
        }

        public string Name { get; set; }
        public IEnumerable<ComplexProperty> ComplexProperties { get; set; }
        public ComplexProperty[] SubProperties { get; set; }

        public SerialisableProperties GetSerializableProperties() {

            var list1 = ComplexProperties.Select(cp => cp.GetSerializableProperties());
            var list2 = SubProperties.Select(cp => cp.GetSerializableProperties());

            return new SerialisableProperties("complexProperty", new List<Property> {
                new StringProperty {
                    Key = "name",
                    Value = Name
                }
            }, new List<Serialisor> {
                new ComplexArrayPropertySerialisor(list1),
                new ComplexArrayPropertySerialisor(list2)
            });
        }
    }
}