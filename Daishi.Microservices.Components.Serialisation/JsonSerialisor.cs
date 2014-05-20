#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public abstract class JsonSerialisor {
        public IEnumerable<JsonSerialisor> InnerSerialisors { get; protected set; }
        public bool IsNamed { get; protected set; }
        public abstract byte[] Serialise(bool isNested = false);
    }
}