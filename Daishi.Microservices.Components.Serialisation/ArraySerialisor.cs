#region Includes

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class ArraySerialisor : Serialisor {
        private readonly string _objectName;
        private readonly IEnumerable<object> _object;

        public ArraySerialisor(IEnumerable<object> @object) {
            _object = @object;
        }

        public ArraySerialisor(string objectName, IEnumerable<object> @object) : this(@object) {
            _objectName = objectName;
        }

        public override byte[] Serialise() {
            using (var writer = new StreamWriter(new MemoryStream(), Encoding.UTF8)) {
                if (!string.IsNullOrEmpty(_objectName))
                    writer.Write(string.Concat("\"", _objectName, "\":"));
                writer.Write("[");

                var values = _object.ToList();
                var valueWriter = new ValueWriter();

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