Feature: SD_CheckoutTwo

@Return
Scenario: Checkout Page Two, Return to Products
Given I am logged in 
And I am on the checkout two page 
When I press "Cancel"
Then I land on the Products Page

@sendOrder
Scenario: Checkout Page Two, Send Order
Given I am logged in 
And I am on the checkout two page 
When I press "Finish"
Then I land on the Checkout Complete Page

@viewItem
Scenario: Checkout Page Two, View Item
Given I am logged in 
And I have an item in my basket
And I am on the checkout two page 
When I press on the Item 
Then I am only able to remove that item from cart
