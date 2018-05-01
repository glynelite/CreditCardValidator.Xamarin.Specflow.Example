Feature: Credit Card Validator
	In order to validate a credit card number,
	as a user I can submit a number to the validator,
	to check if the number contains 16 digits.

Background: 
	Given I am on the card number validator screen

Scenario: Error displayed for less than 16 digits
	Given I enter this number into the card number field: 123456789012345
	And I have tapped the validate card number button
	Then the card number is too short error is displayed

Scenario: Error displayed for submissions greater than 16 digits
	Given I enter this number into the card number field: 12345678901234567
	And I have tapped the validate card number button
	Then card number is too long error is displayed

Scenario: Success screen loads and success message displayed for submissions equal to 16 digits
	Given I enter this number into the card number field: 1234567890123456
	And I have tapped the validate card number button
	Then the validation success screen loads
	And card number is valid message is displayed

Scenario: Make multiple validator submissions
	Given I submit these numbers to the card validator:
	| CardNumber             |
	| 123456789012325352356  |
	| 1234567856             |
	| 1239012345622343334562 |
	| 911                    |
	| 0000000000000000		 |
	Then every number is correctly validated

Scenario: Success screen loads and success message displayed for random 16 digit number
	Given I enter a random number of length 16
	And I have tapped the validate card number button
	Then the validation success screen loads
	And card number is valid message is displayed

Scenario: Error displayed for random number less than 16 digits
	Given I enter a random number of length less than 16
	And I have tapped the validate card number button
	Then the card number is too short error is displayed

Scenario: Error displayed for random number greater than 16 digits
	Given I enter a random number of minimum length 17 and maximum length 30
	And I have tapped the validate card number button
	Then card number is too long error is displayed

Scenario: Error displayed for empty submissions
	Given I have tapped the validate card number button
	Then not a card number error is displayed