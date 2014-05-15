Feature: JsonSerialisor
	In order to serialise a POCO
	As a JsonSerialisor
	I want to serialise a POCO

Scenario: Serialise a POCO
	Given I have supplied a reasonably complex POCO
	And I have instantiated a JsonSerialisor
	When I serialise the POCO
	Then the POCO should be serialised
