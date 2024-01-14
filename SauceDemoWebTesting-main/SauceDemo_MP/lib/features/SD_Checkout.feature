Feature: CheckoutPageFeature
		 As a registered user
		 In order to buy an item
		 I need to enter my details and checkout


@checkouterror
Scenario: Checkout Page : All Fields Empty Examples
Given I have signed in as "standard_user" with the password "secret_sauce"
And I am on the checkout page 
When I enter a <input1> and <input2>
And I press "Continue"
Then I should receive the error containing <error>
Examples:
	| input1    | input2   | error                   |
	| lastname  | postcode | First Name is required  |
	| firstname | postcode | Last Name is required   |
	| firstname | lastname | Postal Code is required |


@checkouterror
Scenario: Checkout Page : All Fields Empty
Given I have signed in as "standard_user" with the password "secret_sauce"
And I am on the checkout page 
When I press "Continue"
Then I should receive the error containing "First Name is required"

@checkoutreturn
Scenario: Checkout Page, Return to Cart
Given I have signed in as "standard_user" with the password "secret_sauce"
And I am on the checkout page 
When I press "Cancel"
Then I land on the Cart Page 

@checkoutcontinue
Scenario: Checkout Page, To Second Checkout Page
Given I have signed in as "standard_user" with the password "secret_sauce"
And I am on the checkout page 
When I fill in the firstname, secondname, postcode
And I press "Continue"
Then I land on the Second Checkout Page