Feature: Account Activation
As a registered patient I want to activate my account so that I can use system services.
Background:
    Given I am on “login” page.
	#the email be consider as username
    And I am registered with the following data : 
| name | password | email              | mobile   | gender | activated | activation code |
| Tala | 123      | talanaji@gmail.com | 00972598 | Female | no        | 012465          |
   Then I should be on "Activate account” page.

Scenario: Send activation email successfully.
	When I press on “Resend activation code”.
	Then I should receive activation email from XXX@YYY.RRR contain the code 012465. 

Scenario: Activate account by entering activation code.
	When I enter 012465 on activation field 
	And press activate 
	Then I should see “successful” message “your account activated successfully” 

