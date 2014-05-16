Feature: SerialiseRawJSON
	In order to serialise raw JSON
	As a JSON Serialisor
	I want to serialise raw JSON

Scenario: Serialise raw JSON
	Given I have added a raw JSON property to an object
	When I serialise the object with a raw JSON property
	Then the object with a raw JSON property should be serialised
