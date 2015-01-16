#region Includes

using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class ComplexObjectDeserialisationFeatureSteps {
        private ComplexObject _complexObject;
        private ComplexObject _deserialisedComplexObject;
        private string _serialisedObject;

        [Given(@"I instantiated a complex object")]
        public void GivenIInstantiatedAComplexObject() {
            _complexObject = new ComplexObject {
                Name = "Complex Object",
                Description = "A complex object",
                ComplexArrayObjects = new List<ComplexArrayObject> {
                    new ComplexArrayObject {
                        Name = "Array Object #1",
                        Description = "The 1st array object"
                    },
                    new ComplexArrayObject {
                        Name = "Array Object #2",
                        Description = "The 2nd array object"
                    }
                },
                Doubles = new List<double> {
                    1d, 2.5d, 10.8d
                }
            };
        }

        [Given(@"I have serialised the complex object")]
        public void GivenIHaveSerialisedTheComplexObject() {
            var serialisableProperties = _complexObject.GetSerializableProperties();
            var writer = new BinaryWriter(new MemoryStream(), new UTF8Encoding(false));

            using (var jsonSerialisor = new StandardJsonSerialisationStrategy(writer)) {
                Json.Serialise(jsonSerialisor, new JsonPropertiesSerialisor(serialisableProperties));
                var bytes = jsonSerialisor.SerialisedObject;

                using (var reader = new StreamReader(new MemoryStream(bytes), Encoding.UTF8)) {
                    _serialisedObject = reader.ReadToEnd();
                }
            }
        }

        [When(@"I deserialise the complex object")]
        public void WhenIDeserialiseTheComplexObject() {
            _deserialisedComplexObject = Json.Deserialise(
                new ComplexObjectDeserialiser(new StandardJsonNameValueCollection(_serialisedObject)), true);
        }

        [Then(@"the complex object should be deserialised correctly")]
        public void ThenTheComplexObjectShouldBeDeserialisedCorrectly() {
            Assert.AreEqual(_complexObject.Name, _deserialisedComplexObject.Name);
            Assert.AreEqual(_complexObject.Description, _deserialisedComplexObject.Description);
            Assert.AreEqual(_complexObject.ComplexArrayObjects.Count, _deserialisedComplexObject.ComplexArrayObjects.Count);
            Assert.AreEqual(_complexObject.Doubles.Count, _deserialisedComplexObject.Doubles.Count);
        }
    }
}