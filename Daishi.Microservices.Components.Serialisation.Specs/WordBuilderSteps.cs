#region Includes

using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class WordBuilderSteps {
        private BinaryReader _reader;
        private WordBuilder _wordBuilder;
        private string _result;

        [Given(@"I have supplied a Stream and associated StreamReader")]
        public void GivenIHaveSuppliedAStreamAndAssociatedStreamReader() {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.SimpleJSON)) {Position = 75};
            _reader = new BinaryReader(stream);
        }

        [Given(@"I have instantiated a new WordBuilder")]
        public void GivenIHaveInstantiatedANewWordBuilder() {
            _wordBuilder = new WordBuilder(_reader);
        }

        [When(@"I invoke the WordBuilder")]
        public void WhenIInvokeTheWordBuilder() {
            _result = new string(_wordBuilder.Build().ToArray());
        }

        [Then(@"a valid alphanumeric string is returned")]
        public void ThenAValidAlphanumericStringIsReturned() {
            Assert.AreEqual("line2", _result);
        }
    }
}