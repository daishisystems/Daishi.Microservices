#region Includes

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class JsonPropertyValidatorSteps {
        private BinaryReader _reader;
        private List<long> _results;

        [Given(@"I have supplied a JSON structure where a certain value is the same as a property name")]
        public void GivenIHaveSuppliedAJSONStructureWhereACertainValueIsTheSameAsAPropertyName() {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.JSONWithSameValueAsPropertyName));
            _reader = new BinaryReader(stream);
        }

        [Given(@"I have supplied a JSON fragment")]
        public void GivenIHaveSuppliedAJSONFragment() {
            var finder = new JsonPropertyFinder(new CharacterFinder(_reader), new WordBuilder(_reader),
                new JsonPropertyValidator(_reader));
            _results = finder.Find("address").ToList();
        }

        [Then(@"the JSON fragment should be validated as a valid JSON property name")]
        public void ThenTheJSONFragmentShouldBeValidatedAsAValidJSONPropertyName() {
            Assert.AreEqual(36, _results[0]);
        }
    }
}