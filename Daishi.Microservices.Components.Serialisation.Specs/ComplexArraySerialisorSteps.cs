#region Includes

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class ComplexArraySerialisorSteps {
        private ComplexArrayObjectContainer _container;
        private ComplexJsonArraySerialisor _serialisor;
        private byte[] _serialisedObject;

        [Given(@"I have supplied an object consisting of a complex array")]
        public void GivenIHaveSuppliedAnObjectConsistingOfAComplexArray() {
            _container = new ComplexArrayObjectContainer {
                ComplexArrayObjects = new List<ComplexArrayObject> {
                    new ComplexArrayObject {
                        Name = "#1",
                        Description = "Complex Array Object #1"
                    },
                    new ComplexArrayObject {
                        Name = "#2",
                        Description = "Complex Array Object #2"
                    },
                    new ComplexArrayObject {
                        Name = "#3",
                        Description = "Complex Array Object #3"
                    }
                }
            };
        }

        [Given(@"I have instantiated a ComplexArraySerialisor")]
        public void GivenIHaveInstantiatedAComplexArraySerialisor() {
            _serialisor = new ComplexJsonArraySerialisor("arrayOfComplexObjects",
                _container.ComplexArrayObjects.Select(c => c.GetSerializableProperties()));
        }

        [When(@"I serialise the object consisting of a complex array")]
        public void WhenISerialiseTheObjectConsistingOfAComplexArray() {
            _serialisedObject = _serialisor.Serialise();
        }

        [Then(@"the object consisting of a complex array should be serialised")]
        public void ThenTheObjectConsistingOfAComplexArrayShouldBeSerialised() {
            string metadata;

            using (var reader = new StreamReader(new MemoryStream(_serialisedObject), Encoding.UTF8))
                metadata = reader.ReadToEnd();

            Assert.AreEqual(Resources.SerialisedArrayOfComplexObjects, metadata);
        }
    }
}