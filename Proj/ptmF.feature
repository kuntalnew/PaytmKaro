Feature: ptmF
Description: Some basic features of Paytm
	
@paytm
Scenario: Verifying number of services provided by Paytm
	Given I am on the home page of Paytm
	Then the number of services can be verified

@paytm
Scenario: Verifying prepaid mobile recharge-1
	Given I am on the home page of Paytm
	And I select the option Mobile
	Then the url should be https://paytm.com/recharge

@paytm
Scenario: Verifying prepaid mobile recharge-2
	Given I am on the home page of Paytm
	And I select the option Mobile
	And I enter valid prepaid mobile number and amount
	When if I click on the button Proceed to recharge
	Then the button Proceed to Pay the amount is displayed and the url is displayed as https://paytm.com/coupons
