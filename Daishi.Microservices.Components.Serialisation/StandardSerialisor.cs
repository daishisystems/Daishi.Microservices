#region Includes

using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public class StandardSerialisor : Serialisor {
        

        

        public StandardSerialisor(SerialisableProperties serialisableProperties) {
            SerialisableProperties = serialisableProperties;
        }

        public StandardSerialisor(SerialisableProperties serialisableProperties,
            bool encapsulate) : this(serialisableProperties) {
            base.encapsulate = encapsulate;
        }

        public override byte[] Serialise() {
            using (var writer = new StreamWriter(new MemoryStream(), new UTF8Encoding(false))) {
                if (!string.IsNullOrEmpty(SerialisableProperties.ObjectName)) {
                    encapsulate = true;
                    writer.Write(string.Concat("\"", SerialisableProperties.ObjectName, "\":"));
                }
                if (encapsulate)
                    writer.Write("{");

                var properties = SerialisableProperties.Properties.ToList();
                var propertyWriter = new PropertyWriter();

                for (var i = 0; i < properties.Count; i++) {
                    var isFinalItem = i.Equals(properties.Count - 1);
                    propertyWriter.Write(properties[i], isFinalItem, writer);
                }

                // todo: Serialise serialisers...

                if (encapsulate)
                    writer.Write("}");
                writer.Flush();
                return ((MemoryStream) writer.BaseStream).ToArray();
            }
        }
    }
}