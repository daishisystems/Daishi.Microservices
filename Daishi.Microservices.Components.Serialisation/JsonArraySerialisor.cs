#region Includes

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class JsonArraySerialisor : JsonSerialisor {
        private readonly string _objectName;
        private readonly IEnumerable<string> _values;
        private readonly JsonPropertyType _propertyType;

        public JsonArraySerialisor(IEnumerable<string> values, JsonPropertyType propertyType) {
            _values = values;
            _propertyType = propertyType;
        }

        public JsonArraySerialisor(string objectName, IEnumerable<string> values,
            JsonPropertyType propertyType) : this(values, propertyType) {
            _objectName = objectName;
        }

        public override byte[] Serialise(bool isNested = false) {
            using (var writer = new StreamWriter(new MemoryStream(), new UTF8Encoding(false))) {
                if (!string.IsNullOrEmpty(_objectName))
                    writer.Write(string.Concat("\"", _objectName, "\":"));
                writer.Write("[");

                var values = _values.ToList();
                var valueWriter = new JsonValueWriter(_propertyType);

                for (var i = 0; i < values.Count; i++) {
                    var isFinalItem = i.Equals(values.Count - 1);
                    valueWriter.Write(values[i], isFinalItem, writer);
                }

                writer.Write("]");
                writer.Flush();
                return ((MemoryStream) writer.BaseStream).ToArray();
            }
        }
    }
}