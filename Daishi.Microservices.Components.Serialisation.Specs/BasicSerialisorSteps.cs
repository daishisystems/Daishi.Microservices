#region Includes

using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class BasicSerialisorSteps {
        [Given(@"I have supplied a simple object")]
        public void GivenIHaveSuppliedASimpleObject() {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have instantiated a BasicSerialisor")]
        public void GivenIHaveInstantiatedABasicSerialisor() {
            ScenarioContext.Current.Pending();
        }

        [When(@"I serialise the simple object")]
        public void WhenISerialiseTheSimpleObject() {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the simple object should be serialised correctly")]
        public void ThenTheSimpleObjectShouldBeSerialisedCorrectly() {
            ScenarioContext.Current.Pending();
        }
    }
}