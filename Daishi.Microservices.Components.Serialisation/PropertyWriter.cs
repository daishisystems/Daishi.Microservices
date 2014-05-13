#region Includes

using System.IO;
using System.Text;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    internal class PropertyWriter {
        public void Write(Property property, bool isFinalItem, StreamWriter writer) {
            var stringBuilder = new StringBuilder(string.Concat("\"", property.Key, "\":"));
            stringBuilder.Append(property.FormatValue());

            if (!isFinalItem)
                stringBuilder.Append(",");
            writer.Write(stringBuilder.ToString());
        }
    }
}