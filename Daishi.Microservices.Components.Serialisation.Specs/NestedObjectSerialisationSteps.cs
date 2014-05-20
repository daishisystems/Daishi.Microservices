#region Includes

using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class NestedObjectSerialisationSteps {
        private NestedObject _nestedObject;
        private byte[] _serialisedObject;

        [Given(@"I have supplied a nested object")]
        public void GivenIHaveSuppliedANestedObject() {
            _nestedObject = new NestedObject {
                Name = "Nested Object",
                Level1 = new Level1 {
                    Name = "Level1",
                    Description = "Level #1",
                    Count = 1,
                    Level2 = new Level2 {
                        Name = "Level2",
                        Description = "Level #2",
                        Count = 2,
                        Level3 = new Level3 {
                            Name = "Level3",
                            Description = "Level #3",
                            Count = 3
                        },
                        Strings = new List<string> {
                            "First", "Second", "Third"
                        }
                    }
                }
            };
        }

        [When(@"I serialise the nested object")]
        public void WhenISerialiseTheNestedObject() {
            var serialisableProperties = _nestedObject.GetSerializableProperties();
            var writer = new BinaryWriter(new MemoryStream(), new UTF8Encoding(false));

            using (var parser = new StandardJsonSerialisor(writer)) {
                Json.Serialise(parser, new PropertiesSerialisor(serialisableProperties));
                _serialisedObject = parser.SerialisedObject;
            }
        }

        [Then(@"the nested object should be serialised")]
        public void ThenTheNestedObjectShouldBeSerialised() {
            string serialisedObject;

            using (var reader = new StreamReader(new MemoryStream(_serialisedObject), Encoding.UTF8))
                serialisedObject = reader.ReadToEnd();

            Assert.AreEqual(Resources.SerialisedNestedObject, serialisedObject);
        }
    }
}