Feature: Account Data Management

Background: 
	Given I am registered with the following data:
	| name | password | email          | mobile   | gender | activated |
	| Tala | aya@123  | tala@gmail.com | 00972598 | Female | yes       |
	#the email will be considered as username
	And I'm logged in
	# with "aya@gmail.com" and "Tala@123"
	And I am on "home" page
	When I click on "MyAccount" link

Scenario: View personal data successfully.
	Then I should see the following data: 
	| name | email         | mobile   | gender |
	| Tala | tala@gmail.com | 00972598 | Female |

Scenario: Update personal data successfully.
	When I press on "Edit"
	Then I should see the following data editable:
         | name | mobile   | gender |
         | Tala | 00972598 | Female |
	When I update the following data: 
	| name        | mobile | gender |
	| Talal gamal | 000000 | Male   |
	Then I should see "successful" message
	And I should see the updated data: 
	| name        | mobile | gender |
	| Talal gamal | 000000 | Male   |

#Scenario Outline: Update my account with invalid personal data - unsuccessful.
#	When I press on "Edit".	
#	And I update the following data: 
#		| name   | mobile   | gender   |
#		| <name> | <mobile> | <gender> |
#	Then I  should see "failure" message "<failure>"
#Examples: 
#| name        | mobile    | gender | failure                                               |
#| Talal gamal | fffffffff | Male   | invalid mobile                                        |
#| 11mustafa   | 000000    | Male   | invalid name, the name should contain characters only |
#| @ffff       | 000000    | Male   | invalid name, the name should contain characters only |
#|             | 000000    | Male   | invalid name, you should enter your name              |


#Scenario Outline: Chang my password successfully.
#	When I click on  "change password" page
#	And I enter <old password>,<new password>and <confirm password>
#	And I press on "Submit changes".
#	Then I  should see "successful" message "you change your password successfully".
#Examples: 
#| old password | new password | confirm password |
#| 123          | 000          | 000              |
#| 666          | 000          | 000              |


#Scenario Outline: Chang my password unsuccessfully.
#
#	When I click on  "change password" page
#	And I enter <old password>,<new password> and <confirm password>
#	And I press on "Submit changes".
#	Then I  should see "failure" message "<failure>".
#
#Examples: 
#| old password | new password | confirm password | failure                     |
#| 123          | 0000         | 000              | invalid password confirm    |
#| 123222       | 000          | 00               | invalid old password        |
#| 123          |              |                  | please enter a new password |

