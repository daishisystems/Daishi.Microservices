#region Includes

using System.Diagnostics;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class SpeedComparisonSteps {
        private Stopwatch _stopwatch;
        private long _result1, _result2;

        [Given(@"I have parsed a JSON object using these components")]
        public void GivenIHaveParsedAJSONObjectUsingTheseComponents() {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.LargeJSON));
            var reader = new BinaryReader(stream);
            var finder = new JsonPropertyFinder(reader, new WordBuilder(reader),
                new JsonPropertyValidator(reader));

            finder.Find("response");
            var jsonObjectBuilder = new JsonObjectBuilder(
                reader, new JsonContainerFactory(), new JsonReader(reader));

            var response = string.Concat("response:", jsonObjectBuilder.Build(JsonObjectType.Object));

            _stopwatch.Stop();
            _result1 = _stopwatch.ElapsedMilliseconds;
        }

        [Given(@"I have parsed a JSON object using JSON\.NET")]
        public void GivenIHaveParsedAJSONObjectUsingJSON_NET() {
            _stopwatch.Start();

            var jsonObject = JObject.Parse(Resources.LargeJSON);
            var response = jsonObject["response"].ToString(Formatting.None);

            _stopwatch.Stop();
            _result2 = _stopwatch.ElapsedMilliseconds;
        }

        [Then(@"the response value associated with these components should be the lowest value")]
        public void ThenTheResponseValueAssociatedWithTheseComponentsShouldBeTheLowestValue() {
            Assert.Greater(_result2, _result1);
        }
    }
}