#region Includes

using System.IO;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class BasicSerialisorSteps {
        private SimpleObject _simpleObject;
        private SimpleObjectThatDoesNotHaveAName _simpleObjectThatDoesNotHaveAName;
        private Serialisor _serialisor;
        private byte[] _serialisedObject;

        [Given(@"I have supplied a simple object")]
        public void GivenIHaveSuppliedASimpleObject() {
            _simpleObject = new SimpleObject {
                Name = "Simple Object",
                Count = 1
            };
        }

        [Given(@"I have supplied a simple object that does not have a name")]
        public void GivenIHaveSuppliedASimpleObjectThatDoesNotHaveAName() {
            _simpleObjectThatDoesNotHaveAName = new SimpleObjectThatDoesNotHaveAName {
                Name = "Simple Object",
                Count = 1
            };
        }

        [Given(@"I have instantiated a BasicSerialisor")]
        public void GivenIHaveInstantiatedABasicSerialisor() {
            _serialisor = new BasicSerialisor(_simpleObject.GetSerializableProperties());
        }

        [Given(@"I have instantiated a BasicSerialisor targetting an object that does not have a name")]
        public void GivenIHaveInstantiatedABasicSerialisorTargettingAnObjectThatDoesNotHaveAName() {
            _serialisor = new BasicSerialisor(_simpleObjectThatDoesNotHaveAName.GetSerializableProperties());
        }

        [When(@"I serialise the simple object")]
        public void WhenISerialiseTheSimpleObject() {
            _serialisedObject = _serialisor.Serialise();
        }

        [Then(@"the simple object should be serialised correctly")]
        public void ThenTheSimpleObjectShouldBeSerialisedCorrectly() {
            string metadata;

            using (var reader = new StreamReader(new MemoryStream(_serialisedObject), Encoding.UTF8))
                metadata = reader.ReadToEnd();

            Assert.AreEqual("\"simpleObject\":{\"name\":\"Simple Object\",\"count\":1}", metadata);
        }

        [Then(@"the simple object that does not have a name should be serialised correctly")]
        public void ThenTheSimpleObjectThatDoesNotHaveANameShouldBeSerialisedCorrectly() {
            string metadata;

            using (var reader = new StreamReader(new MemoryStream(_serialisedObject), Encoding.UTF8))
                metadata = reader.ReadToEnd();

            Assert.AreEqual("{\"name\":\"Simple Object\",\"count\":1}", metadata);
        }
    }
}