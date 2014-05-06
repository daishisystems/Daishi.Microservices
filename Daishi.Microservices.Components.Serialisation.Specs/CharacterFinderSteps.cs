#region Includes

using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Microservices.Components.Serialisation.Specs {
    [Binding]
    public class CharacterFinderSteps {
        private char _character;
        private CharacterFinder _characterFinder;
        private BinaryReader _reader;
        private IEnumerable<long> _results;

        [Given(@"I have supplied a character")]
        public void GivenIHaveSuppliedACharacter() {
            _character = 'l';
        }

        [Given(@"I have instantiated a CharacterFinder")]
        public void GivenIHaveInstantiatedACharacterFinder() {
            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.SimpleJSON));
            _reader = new BinaryReader(stream);
            _characterFinder = new CharacterFinder(_reader);
        }

        [When(@"I invoke the CharacterFinder\.Find method")]
        public void WhenIInvokeTheCharacterFinder_FindMethod() {
            _results = _characterFinder.Find(_character);
        }

        [Then(@"An Iterator containing each matching position is returned")]
        public void ThenAnIteratorContainingEachMatchingPositionIsReturned() {
            var expected = new List<long> {20, 52, 75};
            Assert.That(_results, Is.EquivalentTo(expected));
            _reader.Dispose();
        }
    }
}