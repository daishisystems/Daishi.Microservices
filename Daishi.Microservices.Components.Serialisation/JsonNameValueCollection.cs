#region Includes

using System.Collections.Specialized;

#endregion

namespace Daishi.Microservices.Components.Serialisation {
    public abstract class JsonNameValueCollection {
        protected readonly string json;

        protected JsonNameValueCollection(string json) {
            this.json = json;
        }

        public abstract NameValueCollection Parse(bool mergeArrayValues = false);
    }
}