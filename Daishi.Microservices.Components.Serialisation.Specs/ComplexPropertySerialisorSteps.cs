#region Includes

using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class ComplexPropertySerialisorSteps {
        private ComplexObject _complexObject;
        private StandardSerialisor _basicSerialisor;
        private byte[] _serialisedObject;

        [Given(@"I have supplied a complex property")]
        public void GivenIHaveSuppliedAComplexProperty() {
            _complexObject = new ComplexObject {
                Name = "Complex Object",
                ComplexProperty = new ComplexProperty {
                    Name = "Complex Property",
                    ComplexProperties = new List<ComplexProperty> {
                        new ComplexProperty {
                            Name = "Property #1"
                        },
                        new ComplexProperty {
                            Name = "Property #2",
                            SubProperties = new[] { 
                                new ComplexProperty {
                                    Name = "Low Level Property #1"
                                }
                            }
                        }
                    },
                    SubProperties = new[] {
                        new ComplexProperty {
                            Name = "Property #3"
                        },
                        new ComplexProperty {
                            Name = "Property #4",
                            ComplexProperties = new List<ComplexProperty> {
                                new ComplexProperty {
                                    Name = "Low Level Property #2"
                                }
                            }
                        }
                    }
                }
            };
        }

        [Given(@"I have instantiated a ComplexPropertySerialisor")]
        public void GivenIHaveInstantiatedAComplexPropertySerialisor() {
            _basicSerialisor = new StandardSerialisor(_complexObject.GetSerializableProperties());
            
        }

        [When(@"I serialise the complex property")]
        public void WhenISerialiseTheComplexProperty() {
            using (var serialisor = new StandardJsonSerialisor(new BinaryWriter(new MemoryStream(),
                new UTF8Encoding(false)))) {
                Json.Serialise(serialisor, _basicSerialisor, _complexObject.GetSerializableProperties().Serialisors);
                _serialisedObject = serialisor.SerialisedObject;
            }
        }

        [Then(@"the complex property should be serialised")]
        public void ThenTheComplexPropertyShouldBeSerialised() {
            ScenarioContext.Current.Pending();
        }
    }
}