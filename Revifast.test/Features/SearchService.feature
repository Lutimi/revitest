Feature: Search Provider
	In order to make a reservation
	As a car owner
	I want to look for a technical provider

Scenario: Successful Search
	Given the client specifies valid data to look for a provider
	When the client sends this data to the system
	Then the system will successfuly return a list of providers


Scenario: Unsuccessful Search
	Given the client specifies invalid data to look for a provider
	When the client sends this data to the system
	Then the system will return an error