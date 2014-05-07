Feature: JsonObjectBuilder
	In order to build a JSON object based on a JSON property name
	As a JsonObjectBuilder
	I want to return a well-formed JSON object

Scenario: Return a JSON object
	Given I have found a JSON property
	And I have instantiated a JsonObjectBuilder
	When I invoke the JsonObjectBuilder
	Then the full JSON object should be returned