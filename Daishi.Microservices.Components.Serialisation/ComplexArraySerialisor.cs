#region Includes

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class ComplexArraySerialisor : Serialisor {
        private readonly string _objectName;
        private readonly IEnumerable<SerialisableProperties> _serialisablePropertiesList;

        public ComplexArraySerialisor(string objectName, IEnumerable<SerialisableProperties> serialisablePropertiesList) {
            _objectName = objectName;
            _serialisablePropertiesList = serialisablePropertiesList;
        }

        public override byte[] Serialise() {
            const byte comma = 44;
            var serialisablePropertiesList = _serialisablePropertiesList.ToList();

            using (var writer = new BinaryWriter(new MemoryStream(), new UTF8Encoding(false))) {
                writer.Write(Encoding.UTF8.GetBytes(string.Concat("\"", _objectName, "\":[")));

                for (var i = 0; i < serialisablePropertiesList.Count; i++) {
                    var serialisableProperties = serialisablePropertiesList[i];
                    serialisableProperties.ObjectName = string.Empty;

                    var propertiesSerialisor = new PropertiesSerialisor(serialisableProperties, true);
                    writer.Write(propertiesSerialisor.Serialise());

                    var isLastItem = i.Equals(serialisablePropertiesList.Count - 1);

                    if (!isLastItem)
                        writer.Write(comma);
                }

                writer.Write((byte) 93);
                writer.Flush();

                return ((MemoryStream) writer.BaseStream).ToArray();
            }
        }
    }
}