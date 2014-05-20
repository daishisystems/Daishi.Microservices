Feature: NestedObjectSerialisation
	In order to serialise a nested object
	As a JSON# instance
	I want to serialise a nested object

Scenario: Serialise a nested object
	Given I have supplied a nested object	
	When I serialise the nested object
	Then the nested object should be serialised
