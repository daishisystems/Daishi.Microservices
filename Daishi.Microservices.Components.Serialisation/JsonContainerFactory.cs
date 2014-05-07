#region Includes

using System;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class JsonContainerFactory {
        public void Parse(JsonObjectType jsonObjectType, out char startContainer, out char endContainer) {
            switch (jsonObjectType) {
                case JsonObjectType.Object:
                    startContainer = '{';
                    endContainer = '}';
                    break;
                case JsonObjectType.Array:
                    startContainer = '[';
                    endContainer = ']';
                    break;
                default:
                    throw new NotImplementedException("Invalid JSON Object Type.");
            }
        }
    }
}