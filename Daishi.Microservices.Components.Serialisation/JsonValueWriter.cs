#region Includes

using System.IO;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    internal class JsonValueWriter {
        private readonly JsonPropertyType _propertyType;

        public JsonValueWriter(JsonPropertyType propertyType) {
            _propertyType = propertyType;
        }

        public void Write(object value, bool isFinalItem, StreamWriter writer) {
            if (_propertyType.Equals(JsonPropertyType.Alphabetic))
                writer.Write(isFinalItem ?
                    string.Concat("\"", value, "\"") :
                    string.Concat("\"", value, "\","));
            else
                writer.Write(isFinalItem ? value : string.Concat(value, ","));
        }
    }
}