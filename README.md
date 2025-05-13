# Backend Challenge

## Requirements

There should be possible to create and remove clients:

* A client must be identified by their: Name, CPF and Date of Birth;
* The cpf must be valid (validate it using the check digit) and must be unique in the database, preventing two clients from having the same CPF number.

The digital account must provide the following functionalities:
* The account must be created using the client's CPF;
* Each account must have a balance, number and agency available for consultation;
* It is necessary to have a functionality to issue a bank statement of a given period of time;
* A client can block and unblock their account at any time;
* The following transactions must be possible: Withdrawal and deposit;
	* Deposit: allowed for all active and unlocked accounts;
	* Withdrawal: allowed for all active and unlocked accounts as long as there are sufficient funds for the transaction and the amount does not exceed a configurable daily limit, for example: R$ 2,000.00;
* The account can never have negative balance;


## Migrations:
```
dotnet ef migrations add InitialCreate 
```

## Update tool, if necessary:
```
dotnet tool update --global dotnet-ef --version 9.0.1
```
