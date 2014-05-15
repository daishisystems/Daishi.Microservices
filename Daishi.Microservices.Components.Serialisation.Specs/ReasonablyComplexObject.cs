#region Includes

using System.Collections.Generic;
using System.Globalization;
using System.Linq;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class ReasonablyComplexObject : IHaveSerialisableProperties {
        public string Name { get; set; }
        public double Count { get; set; }
        public IEnumerable<string> Strings { get; set; }
        public float[] Floats { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties("reasonablyComplexObject", new List<Property> {
                new StringProperty {
                    Key = "name",
                    Value = Name
                },
                new NumericProperty {
                    Key = "count",
                    Value = Count
                }
            }, new List<Serialisor> {
                new ArraySerialisor("strings", Strings, JsonPropertyType.Alphabetic),
                new ArraySerialisor("floats", Floats
                    .Select(f => f.ToString(CultureInfo.InvariantCulture))
                    .AsEnumerable(), JsonPropertyType.Numeric)
            });
        }
    }
}