Feature: ComplexPropertySerialisor
	In order to serialise a complex property
	As a ComplexPropertySerialisor
	I want to serialise a complex property

Scenario: Serialise A Complex Property
	Given I have supplied a complex property
	And I have instantiated a ComplexPropertySerialisor
	When I serialise the complex property
	Then the complex property should be serialised
