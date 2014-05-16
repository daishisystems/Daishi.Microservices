#region Includes

using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class ObjectWithSimpleAndArrayPropertiesSteps {
        private ReasonablyComplexObject _reasonablyComplexObject;
        private byte[] _serialisedObject;

        [Given(@"I have supplied a reasonably complex object")]
        public void GivenIHaveSuppliedAReasonablyComplexObject() {
            _reasonablyComplexObject = new ReasonablyComplexObject {
                Name = "Reasonably Complex Object",
                Count = 100,
                Strings = new List<string> {"One", "Two", "Three"},
                Floats = new[] {1f, 2f, 3f}
            };
        }

        [When(@"I serialise the object")]
        public void WhenISerialiseTheObject() {
            var serialisableProperties = _reasonablyComplexObject.GetSerializableProperties();
            var writer = new BinaryWriter(new MemoryStream(), new UTF8Encoding(false));

            using (var jsonSerialisor = new StandardJsonSerialisor(writer)) {
                Json.Serialise(jsonSerialisor, new StandardSerialisor(serialisableProperties),
                    serialisableProperties.Serialisors);

                _serialisedObject = jsonSerialisor.SerialisedObject;
            }
        }

        [Then(@"the object should be serialised correctly")]
        public void ThenTheObjectShouldBeSerialisedCorrectly() {
            string metadata;

            using (var reader = new StreamReader(new MemoryStream(_serialisedObject), Encoding.UTF8))
                metadata = reader.ReadToEnd();

            Assert.AreEqual(Resources.SerialisedReasonablyComplexObject, metadata);
        }
    }
}