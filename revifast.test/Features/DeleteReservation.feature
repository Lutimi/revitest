Feature: DeleteReservation
	In order to delete a reservation 
	As a client
	I want to be able to cancel a reservation

@Delete Reservation
Scenario: Agree deleting
	Given the user agree to 'Cancel' a reservation
	When the user clicks the delete button
	Then the reservation with id '5' should be deleted

Scenario: Disagree Deleting
	Given the user does 'not agree' to cancel a reservation
	When the user tries to delete a reservation
	Then an alert should notify the reservation is still in process