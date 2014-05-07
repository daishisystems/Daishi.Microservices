#region Includes

using System.IO;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class SerialisationSteps {
        private SimpleObject _simpleObject;
        private Serialisor _serialisor;
        private byte[] _serialisedObject;

        [Given(@"I have instantiated a simple object")]
        public void GivenIHaveInstantiatedASimpleObject() {
            _simpleObject = new SimpleObject {
                Name = "Simple Object",
                Count = 1
            };
        }

        [Given(@"I have instantiated a Serialisor")]
        public void GivenIHaveInstantiatedASerialisor() {
            _serialisor = new Serialisor();
        }

        [When(@"I serialise the simple object")]
        public void WhenISerialiseTheSimpleObject() {
            _serialisedObject = _serialisor.Serialise(_simpleObject);
        }

        [Then(@"the simple object should be serialised as well-formed JSON")]
        public void ThenTheSimpleObjectShouldBeSerialisedAsWell_FormedJSON() {
            string metadata;

            using (var reader = new StreamReader(new MemoryStream(_serialisedObject), Encoding.UTF8))
                metadata = reader.ReadToEnd();

            Assert.AreEqual("\"simpleObject\":{\"name\":\"Simple Object\",\"count\":1}", metadata);
        }
    }
}