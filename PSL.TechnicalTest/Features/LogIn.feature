Feature: LogIn

A feature set up to log into amazon

@tag1
Scenario: Log In To Amazon Page With Incorrect Details
	Given I am On Auction Page
	And I Slect Log In
	And I Enter Incorrect LogIn Details
	| Email | Password |
    | damian.paduch@hotmail.com | password |
	When I Select Submit
	Then An Error Is Displayed
