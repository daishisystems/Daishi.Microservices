#region Includes

using System.IO;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    internal class ValueWriter {
        public void Write(string value, bool isFinalItem, StreamWriter writer) {
            writer.Write(isFinalItem ? value : string.Concat(value, ","));
        }
    }
}