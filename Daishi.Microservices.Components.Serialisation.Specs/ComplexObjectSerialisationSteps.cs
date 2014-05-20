#region Includes

using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class ComplexObjectSerialisationSteps {
        private ComplexObject _complexObject;
        private byte[] _serialisedObject;

        [Given(@"I have supplied a complex object consisting of properties, an array, and a complex array")]
        public void GivenIHaveSuppliedAComplexObjectConsistingOfPropertiesAnArrayAndAComplexArray() {
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

        [When(@"I serialise the complex object consisting of properties, an array, and a complex array")]
        public void WhenISerialiseTheComplexObjectConsistingOfPropertiesAnArrayAndAComplexArray() {
            var writer = new BinaryWriter(new MemoryStream(), new UTF8Encoding(false));
            var serialisableProperties = _complexObject.GetSerializableProperties();

            using (var serialisor = new StandardJsonSerialisationStrategy(writer)) {
                Json.Serialise(serialisor, new JsonPropertiesSerialisor(serialisableProperties));
                _serialisedObject = serialisor.SerialisedObject;
            }
        }

        [Then(@"the complex object consisting of properties, an array, and a complex array should be serialised")]
        public void ThenTheComplexObjectConsistingOfPropertiesAnArrayAndAComplexArrayShouldBeSerialised() {
            string metadata;

            using (var reader = new StreamReader(new MemoryStream(_serialisedObject), Encoding.UTF8))
                metadata = reader.ReadToEnd();

            Assert.AreEqual(Resources.SerialisedComplexObject, metadata);
        }
    }
}