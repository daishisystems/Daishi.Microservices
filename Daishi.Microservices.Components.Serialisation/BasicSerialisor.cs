#region Includes

using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class BasicSerialisor : Serialisor {
        private readonly SerialisableProperties _serialisableProperties;
        private bool _encapsulate;

        public BasicSerialisor(SerialisableProperties serialisableProperties, bool encapsulate) {
            _serialisableProperties = serialisableProperties;
            _encapsulate = encapsulate;
        }

        public override byte[] Serialise() {
            using (var writer = new StreamWriter(new MemoryStream(), new UTF8Encoding(false))) {
                if (!string.IsNullOrEmpty(_serialisableProperties.ObjectName)) {
                    _encapsulate = true;
                    writer.Write(string.Concat("\"", _serialisableProperties.ObjectName, "\":"));
                }
                if (_encapsulate)
                    writer.Write("{");

                var properties = _serialisableProperties.Properties.ToList();
                var propertyWriter = new PropertyWriter();

                for (var i = 0; i < properties.Count; i++) {
                    var isFinalItem = i.Equals(properties.Count - 1);
                    propertyWriter.Write(properties[i], isFinalItem, writer);
                }

                if (_encapsulate)
                    writer.Write("}");
                writer.Flush();
                return ((MemoryStream) writer.BaseStream).ToArray();
            }
        }
    }
}