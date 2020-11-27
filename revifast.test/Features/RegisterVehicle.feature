Feature: RegisterVehicle
	In order to keep updated
	As a client
	I want to register my vehicle's data

@Register
Scenario: Correct Data
	Given a user types 'his info'
	When register in the app
	| id | placa	| color	| fecha    |
	| 1  | DEV123   | azul	| 12-09-20 |
	Then our app will 'confirm' the register to the user

Scenario: Wrong Data
	Given a user types 'his info'
	When register in the app
	| id | placa  | color	| fecha		|
	| 1  | DEV123 | 123		| 12-09-20  |
	Then our app will 'warn' the user

Scenario: Not enough data
	Given a user do not type 'his info'
	When register in the app
	| id | placa	| color | fecha    |
	| 1  |			| azul  | 12-09-20 |
	Then our app will send an 'error' to the user