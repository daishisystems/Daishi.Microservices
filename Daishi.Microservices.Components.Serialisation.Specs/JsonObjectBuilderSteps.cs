#region Includes

using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class JsonObjectBuilderSteps {
        private BinaryReader _reader;
        private JsonObjectBuilder _jsonObjectBuilder;
        private string _jsonObject;

        [Given(@"I have found a JSON property")]
        public void GivenIHaveFoundAJSONProperty() {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.LargeJSON));
            _reader = new BinaryReader(stream);
            var finder = new JsonPropertyFinder(new CharacterFinder(_reader), new WordBuilder(_reader),
                new JsonPropertyValidator(_reader));

            var first = finder.Find("response").First();
        }

        [Given(@"I have instantiated a JsonObjectBuilder")]
        public void GivenIHaveInstantiatedAJsonObjectBuilder() {
            _jsonObjectBuilder = new JsonObjectBuilder(_reader, new JsonContainerFactory(), new JsonReader(_reader));
        }

        [When(@"I invoke the JsonObjectBuilder")]
        public void WhenIInvokeTheJsonObjectBuilder() {
            _jsonObject = _jsonObjectBuilder.Build(JsonObjectType.Object);
        }

        [Then(@"the full JSON object should be returned")]
        public void ThenTheFullJSONObjectShouldBeReturned() {
            Assert.AreEqual(18828, _jsonObject.Length);
        }
    }
}