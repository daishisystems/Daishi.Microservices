Feature: JSONCanBeParsedToSimpleDictionary
	In order to ensure that JSON can be parsed to a simple dictionary
	As a SimpleJSONParser
	I want to parse JSON to a simple dictionary

Scenario: Parse JSON to a Simple Dictionary
	Given I have instantiated a SimpleJSONParser	
	When I parse some sample JSON
	Then the resulting dictionary should contain a specified number of items
