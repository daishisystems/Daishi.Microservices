Feature: Serialisation
	In order to ensure that classes can be serialised to JSON in a memory-efficient manner
	As a Serialisatiob library
	I want to serialise classes

Scenario: Serialise a simple object
	Given I have instantiated a simple object
	And I have instantiated a Serialisor
	When I serialise the simple object
	Then the simple object should be serialised as well-formed JSON
