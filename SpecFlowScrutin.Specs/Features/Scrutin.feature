Feature: Scrutin
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator]($projectname$/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: A candidate with more than 50% of the votes is declared the winner
    Given the poll is open
    And the votes are 35, 15, 10
    When the poll of the first round is close
    Then the winner should be Candidate 1
    
Scenario: Display the vote count and percentage for each candidate
    Given the poll is open
    And the votes are 35, 15, 10
    When the poll of the first round is close
    Then the winner should be Candidate 1
    And the vote count and percentage for each candidate should be displayed

Scenario: Second round of voting if no candidate has more than 50% of the votes
    Given the poll is open
    And the votes are 30, 35, 40
    When the poll of the first round is close
    Then there should be a second round
    And the vote count and percentage for each candidate should be displayed
    Given the poll is open for the second round
    And the votes for the second round are 40, 60
    When the poll of the second round is close
    Then the winner should be Candidate 2
    
