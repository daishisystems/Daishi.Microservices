#region Includes

using System.IO;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class ArraySerialisorSteps {
        private SimpleObjectContainingAnArrayPropertyWithoutObjectName _simpleObjectContainingAnArrayPropertyWithoutObjectName;
        private ArraySerialisor _arraySerialisor;
        private byte[] _serialisedObject;

        [Given(@"I have supplied a simple object containing an array property and without an object-name")]
        public void GivenIHaveSuppliedASimpleObjectContainingAnArrayPropertyAndWithoutAnObject_Name() {
            _simpleObjectContainingAnArrayPropertyWithoutObjectName = new SimpleObjectContainingAnArrayPropertyWithoutObjectName {
                Values = new[] {"One", "Two", "Three", "Four", "Five"}
            };
        }

        [Given(@"I instantiated an ArraySerialisor targetting an array property and without an object-name")]
        public void GivenIInstantiatedAnArraySerialisorTargettingAnArrayPropertyAndWithoutAnObject_Name() {
            _arraySerialisor = new ArraySerialisor(
                _simpleObjectContainingAnArrayPropertyWithoutObjectName.Values);
        }

        [When(@"I serialise the simple object with array properties")]
        public void WhenISerialiseTheSimpleObjectWithArrayProperties() {
            _serialisedObject = _arraySerialisor.Serialise();
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