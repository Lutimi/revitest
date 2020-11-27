Feature: CreateReservation
	In order to get my service done
	As a client
	I want to be able to make a reservation

Scenario: Client creates reservation
	Given the client specifies valid data for a reservation
	When the client sends this reservation data to the system
	Then the system will successfuly save the reservation

Scenario: Client fails to create reservation
	Given the client specifies invalid data for a reservation
	When the client sends this reservation data to the system
	Then the system will not save the reservation