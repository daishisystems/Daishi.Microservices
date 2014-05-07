#region Includes

using System.IO;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class JsonPropertyValidatorSteps {
        private BinaryReader _reader;
        private bool _isValid;

        [Given(@"I have supplied a JSON structure")]
        public void GivenIHaveSuppliedAJSONStructure() {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.SimpleJSON));
            _reader = new BinaryReader(stream);
        }

        [Given(@"I have supplied a JSON structure where a certain value is the same as a property name")]
        public void GivenIHaveSuppliedAJSONStructureWhereACertainValueIsTheSameAsAPropertyName() {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.JSONWithSameValueAsPropertyName));
            _reader = new BinaryReader(stream);
        }

        [Given(@"I have supplied a JSON fragment")]
        public void GivenIHaveSuppliedAJSONFragment() {
            var finder = new JsonPropertyFinder(_reader, new WordBuilder(_reader),
                new JsonPropertyValidator(_reader));
            finder.Find("address");
        }

        [When(@"I invoke a JsonPropertyValidator")]
        public void WhenIInvokeAJsonPropertyValidator() {
            var validator = new JsonPropertyValidator(_reader);
            _isValid = validator.Validate();
        }

        [Then(@"the JSON fragment should be validated as a valid JSON property name")]
        public void ThenTheJSONFragmentShouldBeValidatedAsAValidJSONPropertyName() {
            Assert.IsTrue(_isValid);
        }

        [Then(@"the JSON fragment should be validated as an invalid JSON property name")]
        public void ThenTheJSONFragmentShouldBeValidatedAsAnInvalidJSONPropertyName() {
            Assert.IsFalse(_isValid);
        }
    }
}