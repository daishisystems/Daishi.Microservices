Feature: SerialisationSpeedComparison
	In order to prove that JSON# is faster than JSON.NET
	As a JSON# instance
	I want to serialise an object faster than JSON.NET

Scenario: Serialise an object faster than JSON.NET
	Given I have supplied a POCO
	And I have serialised the POCO using JSON#
	When I have serialised the object using JSON.NET
	Then the JSON# serialisation process should be quicker
