Feature: SpeedComparison
	In order to prove that these serialisation components are faster than JSON.NET
	As a speed-test
	I want to compare these components speed with JSON.NET

Scenario: Compare speed
	Given I have parsed a JSON object using these components
	And I have parsed a JSON object using JSON.NET	
	Then the response value associated with these components should be the lowest value
