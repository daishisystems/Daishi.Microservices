#region Includes

using System.IO;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    internal class ValueWriter {
        public void Write(object value, bool isFinalItem, StreamWriter writer) {
            if (value is string)
                writer.Write(isFinalItem ? string.Concat("\"", value, "\"") : string.Concat("\"", value, "\","));
            else
                writer.Write(isFinalItem ? value : string.Concat(value, ","));
        }
    }
}