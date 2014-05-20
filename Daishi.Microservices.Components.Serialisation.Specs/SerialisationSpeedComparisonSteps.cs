#region Includes

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class SerialisationSpeedComparisonSteps {
        private ComplexObject _complexObject;
        private long _result1, _result2;

        [Given(@"I have supplied a POCO")]
        public void GivenIHaveSuppliedAPOCO() {
            _complexObject = new ComplexObject {
                Name = "Complex Object",
                Description = "A complex object",
                ComplexArrayObjects = new List<ComplexArrayObject> {
                    new ComplexArrayObject {
                        Name = "Array Object #1",
                        Description = "The 1st array object"
                    },
                    new ComplexArrayObject {
                        Name = "Array Object #2",
                        Description = "The 2nd array object"
                    }
                },
                Doubles = new List<double> {
                    1d, 2.5d, 10.8d
                }
            };
        }

        [Given(@"I have serialised the POCO using JSON\#")]
        public void GivenIHaveSerialisedThePOCOUsingJSON() {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var writer = new BinaryWriter(new MemoryStream(), new UTF8Encoding(false));
            var serialisableProperties = _complexObject.GetSerializableProperties();

            using (var serialisor = new StandardJsonSerialisor(writer))
                Json.Serialise(serialisor, new PropertiesSerialisor(serialisableProperties));

            stopwatch.Stop();
            _result1 = stopwatch.ElapsedMilliseconds;
        }

        [When(@"I have serialised the object using JSON\.NET")]
        public void WhenIHaveSerialisedTheObjectUsingJSON_NET() {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            JsonConvert.SerializeObject(_complexObject, Formatting.Indented);

            stopwatch.Stop();
            _result2 = stopwatch.ElapsedMilliseconds;
        }

        [Then(@"the JSON\# serialisation process should be quicker")]
        public void ThenTheJSONSerialisationProcessShouldBeQuicker() {
            Console.WriteLine(string.Concat("JSON#: ", _result1));
            Console.WriteLine(string.Concat("JSON.NET: ", _result2));
            Assert.Greater(_result2, _result1);
        }
    }
}