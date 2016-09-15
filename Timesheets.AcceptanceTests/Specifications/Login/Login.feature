Feature: Login
	In order to access Timesheets
	As a user
	I want login

@mytag
Scenario: Login using valid credetials
	Given I am on the home url
	When I click the log on link
	And I enter the following user credentials
		| Field | Value						|
		| #Email  | capturer@entelect.co.za   |
		| #Password | 147Qwert! |
	And I click the Login button
    Then I should be on the home url

Scenario: Login using invalid credentials
	Given I am on the home url
	When I click the log on link
	And I enter the following user credentials
		| Field | Value						|
		| #Email  | capturer@entelect.co.za   |
		| #Password | wrongpassword |
	And I click the Login button
    Then I should remain on the be on the login url
	And I should see an error message
