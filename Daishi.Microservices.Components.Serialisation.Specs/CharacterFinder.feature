Feature: CharacterFinder
	In order to ensure that the correct character is found in a Stream
	As a CharacterFinder
	I want to return an Iterator composed of each position that matches the specified character within the Stream

Scenario: Return an Iterator of positions
	Given I have supplied a character
	And I have instantiated a CharacterFinder
	When I invoke the CharacterFinder.Find method
	Then An Iterator containing each matching position is returned
