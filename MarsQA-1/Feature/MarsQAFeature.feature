Feature: MarsQAFeature

As a MarsQA user, I want to be able to update my profile 
so that people looking for some skills can look into my profile
Note: to add step definitions for newly added features, click on go to definition and copy the given code and paste in step definitions

Scenario: 01 User adds Languages to the profile
	Given User is logged into MarsQA application
	When User adds new language
	Then Newly added language is displayed in the languages list on user profile


Scenario: 02 User edits newly added language 
	Given User is logged into MarsQA application 
	When User edits newly added language 
	Then Language is edited successfully 

Scenario: 03 User delets newly added language 
	Given User is logged into MarsQA application 
	When User delets newly added language
	Then Language is deleted successfully

Scenario: 04 User should be able to add maximum four languages 
	Given User is logged into MarsQA application
	When User adds four languages 
	Then Add new Language button is not visible so user is not able to add fifth language

#Scenario:05 User adds Skill to the profile
#	Given User is logged into MarsQA application 
#	When User adds multiple new skills 
#	Then Newly added skills are displayed in the skills list on user profile 

#Scenario: 06 User edits newly added skill 
#	Given User is logged into MarsQA application
#	When User edits newly added Skill 
#	Then Skill is edited successfully 
#
#Scenario: 07 User delets newly added skill 
#	Given User is logged into MarsQA application 
#	When User delets newly added skill
#	Then Skill is deleted successfully
#
#Scenario: 08 User adds description 
#	Given User is logged into MarsQA application 
#	When User adds description
#	Then Description is added successfully
#
#Scenario: 09 User adds description 
#	Given User is logged into MarsQA application 
#	When User adds description
#	Then Description is added successfully
#
#Scenario: 10 User adds Education to the profile
#	Given User is logged into MarsQA application 
#	When User adds multiple new skills 
#	Then Newly added skills are displayed in the skills list on user profile 
#
#Scenario: 11 User edits newly added education 
#	Given User is logged into MarsQA application
#	When User edits newly added Skill 
#	Then Skill is edited successfully 
#
#Scenario: 12 User delets newly added education 
#	Given User is logged into MarsQA application 
#	When User delets newly added skill
#	Then Skill is deleted successfully
