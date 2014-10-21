#region Includes

using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class SimpleJSONIsDeserialisedSteps {
        private SimpleObjectDeserialiser _simpleObjectDeserialiser;
        private SimpleObject _simpleObject;

        [Given(@"I have instantiated an extension of Deserialiser(.*)")]
        public void GivenIHaveInstantiatedAnExtensionOfDeserialiser(string p0) {
            _simpleObjectDeserialiser = new SimpleObjectDeserialiser(new SimpleJSONParser(Resources.VerySimpleJSON));
        }

        [When(@"I deserialise a simple JSON object")]
        public void WhenIDeserialiseASimpleJSONObject() {
            _simpleObject = Json.Deserialise(_simpleObjectDeserialiser);
        }

        [Then(@"the corresponding POCO should be set appropriately")]
        public void ThenTheCorrespondingPOCOShouldBeSetAppropriately() {
            Assert.AreEqual("Simple Object", _simpleObject.Name);
            Assert.AreEqual(1, _simpleObject.Count);
        }
    }
}