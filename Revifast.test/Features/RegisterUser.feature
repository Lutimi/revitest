Feature: RegisterUser
	In order to register on the platform
	As a client
	I want them to tell me if I register correctly

@Register User
Scenario: the user tries to register on the platform
	Given user adds correct 'email' and 'password' to register
	When The user clicks the register button
	Then the system will record the user's data in the database 'email' and 'password'.

Scenario: the user enters incorrect data to register
	Given the user enters an existing 'email' and 'password'
	When The user clicks the register button
	Then The system will notify the user that it could not be registered and to correct the data.



