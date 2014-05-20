#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class Level1 : Level {
        public Level2 Level2 { get; set; }

        public override SerialisableProperties GetSerializableProperties() {
            var serialisableProperties = base.GetSerializableProperties();
            serialisableProperties.ObjectName = "level1";
            serialisableProperties.Serialisors = new List<Serialisor> {
                new PropertiesSerialisor(Level2.GetSerializableProperties())
            };

            return serialisableProperties;
        }
    }
}