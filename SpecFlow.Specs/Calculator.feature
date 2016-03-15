Feature: Calculator

       In order to avoid silly mistakes
       As a math idiot
       I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
       Given I have entered 50 into the calculator
       And I have also entered 70 into the calculator
       When I press add
       Then the result should be 120 on the screen

@myothertag
Scenario: Add two high numbers
       Given I have entered 40000 into the calculator
       And I have also entered 10000 into the calculator
       When I press add
       Then the result should be 50000 on the screen