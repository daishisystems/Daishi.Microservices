Feature: WordBuilder
	In order to ensure that a full word is constructed
	As a WordBuilder
	I want to return a series of characters until a non-alphanumeric character is found

Scenario: Return an alphanumeric string
	Given I have supplied a Stream and associated StreamReader
	And I have instantiated a new WordBuilder
	When I invoke the WordBuilder
	Then a valid alphanumeric string is returned