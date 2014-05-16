#region Includes

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class ComplexArrayPropertySerialisor : Serialisor {
        private readonly IEnumerable<SerialisableProperties> _serialisableProperties;

        public ComplexArrayPropertySerialisor(IEnumerable<SerialisableProperties> serialisableProperties) {
            _serialisableProperties = serialisableProperties;
        }

        public override byte[] Serialise() {
            using (var writer = new StreamWriter(new MemoryStream(), new UTF8Encoding(false))) {
                var serialisablePropertiesList = _serialisableProperties.ToList();

                writer.Write("[");

                for (var i = 0; i < serialisablePropertiesList.Count; i++) {
                    var serialisableProperties = serialisablePropertiesList[i];

                    if (!string.IsNullOrEmpty(serialisableProperties.ObjectName)) {
                        encapsulate = true;
                        writer.Write(string.Concat("\"", serialisableProperties.ObjectName, "\":"));
                    }
                    if (encapsulate)
                        writer.Write("{");

                    var properties = serialisableProperties.Properties.ToList();
                    var propertyWriter = new PropertyWriter();

                    for (var j = 0; i < properties.Count; i++) {
                        var isFinalItem = j.Equals(properties.Count - 1);
                        propertyWriter.Write(properties[j], isFinalItem, writer);
                    }

                    if (encapsulate)
                        writer.Write("}");
                }

                writer.Write("]");

                writer.Flush();
                return ((MemoryStream) writer.BaseStream).ToArray();
            }
        }
    }
}