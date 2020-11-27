Feature: reservationdetails
	As a user	
	I want to visualize the details of my reservation
	In order to verofy my reservation information

@mytag
Scenario: User want to verify the authenticity of his reservation
	Given a verfied user
	And  the user want to validate his reservation information
	When the user click on the reservation information icon
	Then the system will show the reservation information


	Scenario: User want to know if the reservation exist
	When the user click on the reservation information icon
	And  see the following details
		| Fecha        | Hora | observaciones | Vehiculo | Local | Confirmado |
		| 12 de Marzpo |12:00 |Reserva Pagada |BCSPN     |Surco  | Si         |
	And click on view reservation
	Then the system will show the reservation and it status