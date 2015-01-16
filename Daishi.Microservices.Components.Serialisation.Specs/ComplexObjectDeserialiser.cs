#region Includes

using System;
using System.Collections.Generic;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    internal class ComplexObjectDeserialiser : Deserialiser<ComplexObject> {
        public ComplexObjectDeserialiser(JsonNameValueCollection jsonNameValueCollection) : base(jsonNameValueCollection) {}

        public override ComplexObject Deserialise(bool mergeArrayValues = false) {
            var properties = jsonNameValueCollection.Parse(mergeArrayValues);

            var complexObject = new ComplexObject {
                Name = properties["complexObject.name"],
                Description = properties["complexObject.description"],
                ComplexArrayObjects = new List<ComplexArrayObject>(),
                Doubles = new List<double>()
            };

            var complexArrayObjectNames = properties["complexObject.complexArrayObjects.name"].Split(',');
            var complexArrayObjectDescriptions = properties["complexObject.complexArrayObjects.description"].Split(',');

            for (var i = 0; i < complexArrayObjectNames.Length; i++) {
                var complexArrayObjectName = complexArrayObjectNames[i];

                complexObject.ComplexArrayObjects.Add(new ComplexArrayObject {
                    Name = complexArrayObjectName,
                    Description = complexArrayObjectDescriptions[i]
                });
            }

            var complexArrayObjectDoubles = properties["complexObject.doubles"].Split(',');

            foreach (var @double in complexArrayObjectDoubles)
                complexObject.Doubles.Add(Convert.ToDouble(@double));

            return complexObject;
        }
    }
}