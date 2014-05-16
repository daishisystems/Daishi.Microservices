Feature: ComplexArraySerialisor
	In order to serialise a complex array
	As a ComplexArraySerialisor
	I want to serialise a complex array

Scenario: Serialise a Complex Array
	Given I have supplied an object consisting of a complex array
	And I have instantiated a ComplexArraySerialisor
	When I serialise the object consisting of a complex array 
	Then the object consisting of a complex array should be serialised