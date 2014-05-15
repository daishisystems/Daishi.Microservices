#region Includes

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class ArraySerialisor : Serialisor {
        private readonly string _objectName;
        private readonly IEnumerable<string> _values;
        private readonly JsonPropertyType _propertyType;

        public ArraySerialisor(IEnumerable<string> values, JsonPropertyType propertyType) {
            _values = values;
            _propertyType = propertyType;
        }

        public ArraySerialisor(string objectName, IEnumerable<string> values,
            JsonPropertyType propertyType) : this(values, propertyType) {
            _objectName = objectName;
        }

        public override byte[] Serialise() {
            using (var writer = new StreamWriter(new MemoryStream(), new UTF8Encoding(false))) {
                if (!string.IsNullOrEmpty(_objectName))
                    writer.Write(string.Concat("\"", _objectName, "\":"));
                writer.Write("[");

                var values = _values.ToList();
                var valueWriter = new ValueWriter(_propertyType);

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