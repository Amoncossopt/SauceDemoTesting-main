Feature: SD_Product
	Exploring the interactions with the
	individual product pages

#Background: 
#	Given I have signed in as "standard_user" with the password "secret_sauce"
#	And I click the <product_name> product button
	#Examples:
	#	| product_name                      |
	#	| Sauce Labs Backpack               |
	#	| Sauce Labs Bolt T-Shirt           |
	#	| Sauce Labs Bike Light             |
	#	| Sauce Labs Fleece Jacket          |
	#	| Sauce Labs Onesie                 |
	#	| Test.allTheThings() T-Shirt (Red) |

@Product
Scenario: Add item to cart
	Given I have signed in as "standard_user" with the password "secret_sauce"
	And I click the "Sauce Labs Backpack" product button
	And There are no items in my cart
	When I click the add to cart button
	Then the cart number size increases by one
	And the add to cart button changes to remove

@Product
Scenario: Remove item From cart
	Given I have signed in as "standard_user" with the password "secret_sauce"
	And I click the "Sauce Labs Backpack" product button
	And I click the add to cart button
	And There are "1" items in my cart
	When I click the remove button
	Then the cart number size decreases by one
	And the remove button changes to add to cart

@Product
Scenario: Back to products page from product
	Given I have signed in as "standard_user" with the password "secret_sauce"
	And I click the "Sauce Labs Backpack" product button
	When I click the back button
	Then I should be on the products page