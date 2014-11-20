#region Includes

using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class FindAllBlackboardsSteps {
        private JsonParser _jsonParser;

        [Given(@"I have parsed a JSON school file")]
        public void GivenIHaveParsedAJSONSchoolFile() {
            _jsonParser = new JsonObjectParser();

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.SchoolJson))) {
                Json.Parse(_jsonParser, stream, "blackboard");
            }
        }

        [Then(@"I should find the correct number of blackboards")]
        public void ThenIShouldFindTheCorrectNumberOfBlackboards() {
            Assert.AreEqual(2, _jsonParser.Objects.Count());
        }
    }
}