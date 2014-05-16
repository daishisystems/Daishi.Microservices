Feature: ComplexObjectSerialisation
	In order to serialise a complex object consisting of properties, an array, and a complex array
	As a JSON serialisor
	I want to serialise a complex object consisting of properties, an array, and a complex array

Scenario: Serialise a complex object consisting of properties, an array, and a complex array
	Given I have supplied a complex object consisting of properties, an array, and a complex array
	When I serialise the complex object consisting of properties, an array, and a complex array
	Then the complex object consisting of properties, an array, and a complex array should be serialised
