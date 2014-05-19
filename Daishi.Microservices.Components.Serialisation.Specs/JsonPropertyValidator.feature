Feature: JsonPropertyValidator
	In order to ensure that a given JSON fragment is a valid property name
	As a JsonPropertyValidator
	I want to validate the JSON fragment

Scenario: Validate a JSON fragment
	Given I have supplied a JSON structure where a certain value is the same as a property name
	And I have supplied a JSON fragment	
	Then the JSON fragment should be validated as a valid JSON property name