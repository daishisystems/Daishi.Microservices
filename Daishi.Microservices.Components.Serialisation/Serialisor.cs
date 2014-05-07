#region Includes

using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class Serialisor {
        public Serialisor() {}

        public byte[] Serialise(IHaveSerialisableProperties @object) {
            var serialisableProperties = @object.GetSerializableProperties();
            using (var writer = new StreamWriter(new MemoryStream(), Encoding.UTF8)) {
                writer.Write(string.Concat("\"", serialisableProperties.ObjectName, "\":"));
                writer.Write("{");

                var properties = serialisableProperties.Properties.ToList();
                var propertyWriter = new PropertyWriter();

                for (var i = 0; i < properties.Count; i++) {
                    var isFinalItem = i.Equals(properties.Count - 1);
                    propertyWriter.Write(properties[i], isFinalItem, writer);
                }

                writer.Write("}");
                writer.Flush();
                return ((MemoryStream) writer.BaseStream).ToArray();
            }
        }
    }
}