Feature: ComplexObjectDeserialisationFeature
	In order to ensure that complex objects can be deserialised by JSON#	
	I want to deserialise a complex object

Scenario: Deserialise a complex object
	Given I instantiated a complex object
	And I have serialised the complex object
	When I deserialise the complex object
	Then the complex object should be deserialised correctly
