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
        public Level2 Level2 { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties("reasonablyComplexObject", new List<JsonProperty> {
                new StringJsonProperty {
                    Key = "name",
                    Value = Name
                },
                new NumericJsonProperty {
                    Key = "count",
                    Value = Count
                }
            }, new List<JsonSerialisor> {
                new JsonArraySerialisor("strings", Strings, JsonPropertyType.Alphabetic),
                new JsonArraySerialisor("floats", Floats
                    .Select(f => f.ToString(CultureInfo.InvariantCulture))
                    .AsEnumerable(), JsonPropertyType.Numeric),
                new JsonPropertiesSerialisor(Level2.GetSerializableProperties())
            });
        }
    }
}