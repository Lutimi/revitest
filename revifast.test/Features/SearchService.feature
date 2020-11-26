Feature: SearchService
	In order to make a reservation
	As a client
	I need to be able to search for a technical service provider

Scenario: Succcesful search
	Given the user is registered
	And the user is looking for an specific service provider with valid data
	When the user queries the system through the API
	Then the system will return a list of technical providers

Scenario: Unsucccesful search
	Given the user is registered
	And the user is looking for an specific service provider with invalid data
	When the user queries the system through the API
	Then the system will return an error