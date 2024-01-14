Feature: SD_Cart
	Exploring the cart page functionality

@Cart
Scenario: Checkout Item
	Given I have signed in as "standard_user" with the password "secret_sauce"
	And I click the "Sauce Labs Backpack" add to cart button
	And I go to the cart page
	When I click the checkout button
	Then I should be on the checkout page

@Cart
Scenario: Remove Item
	Given I have signed in as "standard_user" with the password "secret_sauce"
	And I click the "Sauce Labs Backpack" add to cart button
	And I go to the cart page
	When I click remove for the product "Sauce Labs Backpack"
	Then I should no longer see that item in my cart

@Cart
Scenario: Continue Shopping
	Given I have signed in as "standard_user" with the password "secret_sauce"
	And I go to the cart page
	When I click the continue shopping button
	Then I should land on the products page