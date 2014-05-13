#region Includes

using System.IO;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class ArraySerialisorSteps {
        private SimpleObjectContainingAnArrayProperty _simpleObjectContainingAnArrayProperty;
        private SimpleObjectContainingAnArrayPropertyWithoutObjectName _simpleObjectContainingAnArrayPropertyWithoutObjectName;
        private ArraySerialisor _arraySerialisor;
        private byte[] _serialisedObject;

        [Given(@"I have supplied a simple object containing an array property")]
        public void GivenIHaveSuppliedASimpleObjectContainingAnArrayProperty() {
            _simpleObjectContainingAnArrayProperty = new SimpleObjectContainingAnArrayProperty {
                Values = new[] {"One", "Two", "Three", "Four", "Five"}
            };
        }

        [Given(@"I have supplied a simple object containing an array property and without an object-name")]
        public void GivenIHaveSuppliedASimpleObjectContainingAnArrayPropertyAndWithoutAnObject_Name() {
            _simpleObjectContainingAnArrayPropertyWithoutObjectName = new SimpleObjectContainingAnArrayPropertyWithoutObjectName {
                Values = new[] {"One", "Two", "Three", "Four", "Five"}
            };
        }

        [Given(@"I instantiated an ArraySerialisor")]
        public void GivenIInstantiatedAnArraySerialisor() {
            _arraySerialisor = new ArraySerialisor();
        }

        [When(@"I serialise the simple object containing an array property")]
        public void WhenISerialiseTheSimpleObjectContainingAnArrayProperty() {
            _serialisedObject = _arraySerialisor.Serialise(_simpleObjectContainingAnArrayProperty);
        }

        [When(@"I serialise the simple object containing an array property and without an object-name")]
        public void WhenISerialiseTheSimpleObjectContainingAnArrayPropertyAndWithoutAnObject_Name() {
            _serialisedObject = _arraySerialisor.Serialise(_simpleObjectContainingAnArrayPropertyWithoutObjectName);
        }

        [Then(@"the simple object containing the array property should be serialised")]
        public void ThenTheSimpleObjectContainingTheArrayPropertyShouldBeSerialised() {
            string metadata;

            using (var reader = new StreamReader(new MemoryStream(_serialisedObject), Encoding.UTF8))
                metadata = reader.ReadToEnd();

            Assert.AreEqual("\"simpleObject\":[\"One\",\"Two\",\"Three\",\"Four\",\"Five\"]", metadata);
        }

        [Then(@"the simple object containing the array property and without an object-name should be serialised")]
        public void ThenTheSimpleObjectContainingTheArrayPropertyAndWithoutAnObject_NameShouldBeSerialised() {
            string metadata;

            using (var reader = new StreamReader(new MemoryStream(_serialisedObject), Encoding.UTF8))
                metadata = reader.ReadToEnd();

            Assert.AreEqual("[\"One\",\"Two\",\"Three\",\"Four\",\"Five\"]", metadata);
        }
    }
}