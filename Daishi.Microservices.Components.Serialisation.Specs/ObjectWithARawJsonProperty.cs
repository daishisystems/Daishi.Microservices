#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class ObjectWithARawJsonProperty : IHaveSerialisableProperties {
        public string RawJson { get; set; }

        public SerialisableProperties GetSerializableProperties() {
            return new SerialisableProperties("objectWithARawJsonProperty", new List<Property> {
                new RawProperty {
                    Key = "raw",
                    Value = RawJson
                }
            });
        }
    }
}