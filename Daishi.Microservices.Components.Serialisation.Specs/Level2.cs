﻿#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class Level2 : Level {
        public Level3 Level3 { get; set; }
        public IEnumerable<string> Strings { get; set; }

        public override SerialisableProperties GetSerializableProperties() {
            var serialisableProperties = base.GetSerializableProperties();
            serialisableProperties.ObjectName = "level2";
            serialisableProperties.Serialisors = new List<JsonSerialisor> {
                new JsonPropertiesSerialisor(Level3.GetSerializableProperties()),
                new JsonArraySerialisor("strings", Strings, JsonPropertyType.Alphabetic)
            };

            return serialisableProperties;
        }
    }
}