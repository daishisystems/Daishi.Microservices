#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    public class ComplexObject : IHaveSerialisableProperties {
        public string Name { get; set; }
        public ComplexProperty ComplexProperty { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties( "complexObject", new List<Property> {
                new StringProperty {
                    Key = "name",
                    Value = Name
                }
            }, new List<Serialisor> {
                new StandardSerialisor(ComplexProperty.GetSerializableProperties())
            });
        }
    }
}