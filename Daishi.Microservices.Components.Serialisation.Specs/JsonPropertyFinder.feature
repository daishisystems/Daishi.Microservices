Feature: JsonPropertyFinder
	In order to ensure that the specified JSON property is found
	As a JsonPropertyFinder
	I want to return the position of the specified property in a Stream

Scenario: Get the specified property's position in a Stream
	Given I have supplied a JSON property
	When I invoke a JsonPropertyFinder
	Then the JsonPropertyFinder will return the property's position in the Stream