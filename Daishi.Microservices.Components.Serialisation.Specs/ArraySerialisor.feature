Feature: ArraySerialisor
	In order to ensure that arrays are serialised correctly
	As an ArraySerialisor
	I want to serialise an array

Scenario: Serialise an array without an object-name
	Given I have supplied a simple object containing an array property and without an object-name
	And I instantiated an ArraySerialisor targetting an array property and without an object-name
	When I serialise the simple object with array properties
	Then the simple object containing the array property and without an object-name should be serialised
