Feature: SimpleJSONIsDeserialised
	In order to ensure that a simple JSON object is deserialised
	As a Deserialiser
	I want to deserialise the simple JSON object.

Scenario: Deserialise a Simple JSON object
	Given I have instantiated an extension of Deserialiser<T>	
	When I deserialise a simple JSON object
	Then the corresponding POCO should be set appropriately