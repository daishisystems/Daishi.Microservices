Feature: FindAllBlackboards
	In order to ensure that all blackboards can be found
	As a JSON# instance
	I want to find all blackboards from a school file

Scenario: Find all blackboards from a school file
	Given I have parsed a JSON school file
	Then I should find the correct number of blackboards
