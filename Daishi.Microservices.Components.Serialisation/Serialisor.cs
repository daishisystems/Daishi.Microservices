#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public abstract class Serialisor {
        public IEnumerable<Serialisor> InnerSerialisors { get; set; }
        public abstract byte[] Serialise(bool isNested = false);
    }
}