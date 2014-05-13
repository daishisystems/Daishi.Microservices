Feature: BasicSerialisor
	In order to ensure that simple objects can be serialised
	As a BasicSerialisor
	I want to serialise a simple object

Scenario: Serialise a simple object
	Given I have supplied a simple object
	And I have instantiated a BasicSerialisor
	When I serialise the simple object
	Then the simple object should be serialised correctly
