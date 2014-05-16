#region Includes

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class ComplexArrayObjectContainer : IHaveSerialisableProperties {
        public string Name { get; set; }
        public List<ComplexArrayObject> ComplexArrayObjects { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties(new List<Property> {
                new StringProperty {
                    Key = "name",
                    Value = Name
                }
            }, new List<Serialisor> {
                new ComplexArraySerialisor("arrayOfComplexObjects",
                    ComplexArrayObjects.Select(c => c.GetSerializableProperties()))
            });
        }
    }
}