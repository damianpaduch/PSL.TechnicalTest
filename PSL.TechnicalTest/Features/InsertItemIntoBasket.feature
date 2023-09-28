Feature: Example

This is an example autoamtion test for addin items to bascet on amazon

@tag1
Scenario: Add Item To Basket On Amazon
	Given I am on the Amazon Home Page
	And I search for an item
	When I select add to basket 
	Then Item is successully added to the basket
