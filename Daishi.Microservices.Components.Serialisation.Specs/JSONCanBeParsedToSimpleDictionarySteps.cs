#region Includes

using System.Collections.Specialized;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class JSONCanBeParsedToSimpleDictionarySteps {
        private StandardJsonNameValueCollection _simpleJSONParser;
        private NameValueCollection _result;

        [Given(@"I have instantiated a SimpleJSONParser")]
        public void GivenIHaveInstantiatedASimpleJSONParser() {
            _simpleJSONParser = new StandardJsonNameValueCollection(Resources.LargeJSON);
        }

        [When(@"I parse some sample JSON")]
        public void WhenIParseSomeSampleJSON() {
            _result = _simpleJSONParser.Parse();
        }

        [Then(@"the resulting dictionary should contain a specified number of items")]
        public void ThenTheResultingDictionaryShouldContainASpecifiedNumberOfItems() {
            Assert.AreEqual(748, _result.Count);
        }
    }
}