Feature: SD_Products
	In order to be able to buy items
	As a registered user of the sauce demo website
	I want to be able to view and order products appropriately


Background: The user is on the products page
	Given I am on the products page
	

@AddingItemToCart
Scenario: Adding item to cart
	When I click to add an item to cart
	Then the cart number increases by one
	And the add to cart button on the added item changes text to remove

@AddingItemToCart
Scenario: Adding an item and clicking on item description
	When I click to add an item to cart
	And I click to go to that item's page
	Then I am only able to remove that item from cart

@RemovingItemFromCart
Scenario: Removing an item from cart
	When I click to add an item to cart
	And I click to remove that item from cart
	Then the remove button on the removed item changes text to add to cart

@OrderingProducts
Scenario: Order products by price ascending
	When I select Price (low to high)
	Then the products are ordered in ascending price order

@OrderingProducts
Scenario: Order products by price descending
	When I select Price (high to low)
	Then the products are ordered in descending price order

@OrderingProducts
Scenario: Order products in alphabetical order
	When I select Name (A to Z)
	Then the products are ordered in alphabetical order

@OrderingProducts
Scenario: Order products in reverse alphabetical order
	When I select Name (Z to A)
	Then the products are ordered in reverse alphabetical order


#@NavigatingToCart
#Scenario: Navigating to cart
#	Given I am on the products page
#	When I press the cart icon
#	Then I am taken to the checkout page