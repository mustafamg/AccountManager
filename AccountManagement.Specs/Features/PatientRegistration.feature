Feature: Patient Registration

Background:
     Given I am on "Main" page.
     When I click on "Registration" link.
	Then I should see "Register User" form.

Scenario: Successful registration 
	When I enter the following data:

    | name  | email             | password | confirm password | mobile | gender |
    | Nehad | nnnHHHH@gmail.com | 123      | 123              | 123456 | female |
	And I press on "Register" button.

  	Then I should see "successful" message "you registered successfully, check your email to activate your account".
 	And I should receive activation email.

#Scenario Outline: Unsuccessful registration.
#	When I enter the following data:
#    |<name>	|   <email>		| <password>	|<confirm password>|<mobile>|<gender>|
		
#	Then I should see "failure" message "<failure>".
#Examples: 
#| name | email | new password | confirm password | mobile | gender | failure                                      |
#|      |       |              |                  |        |        | please Enter required data                   |
#|      |       |              |                  |        |        | Password and confirm password does not match |
#|      |       |              |                  |        |        | Email already exist                          |
#|      |       |              |                  |        |        | you must Enter Name                          |
#|      |       |              |                  |        |        | you must Enter Email                         |
#|      |       |              |                  |        |        | you must Enter password                      |
#|      |       |              |                  |        |        | you must Enter confirm  password             |
#|      |       |              |                  |        |        | mobile should be number                      |
