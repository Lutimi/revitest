Feature: MakeReservation
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Make a successful reservation on ReviFast.
	Given the user complete the requirements
	And the application validate all the infomation
	When the user send the data on the reservation page
	Then the system will show the successfull message

@mytag
Scenario: Give an incorrect data on reservation page.
	Given the user complete the requirements with an incorrect data
	And the application verify all the infomation
	When the user send the data on the reservation page
	Then the system will show an Error message

@mytag
Scenario: User doesn't choose a local on the reservation page.
	Given the user didnt complete the information, don't specify the local 
	And the application check if everything is ok
	When the user send the data on the reservation page
	Then the system will show an Local Error message

@mytag
Scenario: User doesn't enter the full information.
	Given the user didnt complete the information 
	And the application check if something if missing
	When the user send the data on the reservation page
	Then the system will show an Info Error message		
