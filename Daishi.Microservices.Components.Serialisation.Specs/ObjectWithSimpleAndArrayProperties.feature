Feature: ObjectWithSimpleAndArrayProperties
	In order to ensure that objects consisting of both simple and array-based properties are serialised
	As a JSON serialiser
	I want to serialise a reasonably complex object

Scenario: Serialise a reasonably complex object
	Given I have supplied a reasonably complex object	
	When I serialise the object
	Then the object should be serialised correctly
