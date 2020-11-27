Feature: ViewReservationHistory
	In order to list a reservation history
	As a client
	I want to be able to list my reservations

@List Reservations
Scenario: Accept to enter the reservation history
	Given the user agrees to 'list' their reservations
	When the user clicks the button list reservations
	Then reservations with id '3' must be list

Scenario: deny entry to reservation history
	Given the user has no reservations to list from his 'nolist'
	When the user tries to list their reservations with their '40'
	Then the system notifies that there is no record of reservations.