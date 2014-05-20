#region Includes

using System.IO;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class SerialiseRawJSONSteps {
        private ObjectWithARawJsonProperty _objectWithARawJsonProperty;
        private byte[] _serialisedObject;

        [Given(@"I have added a raw JSON property to an object")]
        public void GivenIHaveAddedARawJSONPropertyToAnObject() {
            _objectWithARawJsonProperty = new ObjectWithARawJsonProperty {
                RawJson = Resources.RawJSON
            };
        }

        [When(@"I serialise the object with a raw JSON property")]
        public void WhenISerialiseTheObjectWithARawJSONProperty() {
            var writer = new BinaryWriter(new MemoryStream(), new UTF8Encoding(false));
            var serialisableProperties = _objectWithARawJsonProperty.GetSerializableProperties();

            using (var serialisor = new StandardJsonSerialisor(writer)) {
                Json.Serialise(serialisor, new PropertiesSerialisor(serialisableProperties));
                _serialisedObject = serialisor.SerialisedObject;
            }
        }

        [Then(@"the object with a raw JSON property should be serialised")]
        public void ThenTheObjectWithARawJSONPropertyShouldBeSerialised() {
            string metadata;

            using (var reader = new StreamReader(new MemoryStream(_serialisedObject), Encoding.UTF8))
                metadata = reader.ReadToEnd();

            Assert.AreEqual(Resources.SerialisedObjectWithARawJSONProperty, metadata);
        }
    }
}