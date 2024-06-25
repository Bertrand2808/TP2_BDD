Feature: Scrutin
  In order to determine the winner of an election
  As a client of the API
  I want to calculate the result of the election and get the winner

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

  Scenario: Handle tie between candidates in the first round
    Given the poll is open
    And the votes are 25, 25, 50
    When the poll of the first round is close
    Then there should be a second round
    And the vote count and percentage for each candidate should be displayed
    Given the poll is open for the second round
    And the votes for the second round are 50, 50
    When the poll of the second round is close
    Then the result should be "No winner due to a tie"

  Scenario: Handle white votes
    Given the poll is open
    And the votes are 25, 25, 50, 10
    When the poll of the first round is close
    Then there should be a second round
    And the vote count and percentage for each candidate should be displayed
    Given the poll is open for the second round
    And the votes for the second round are 50, 50, 10
    When the poll of the second round is close
    Then the result should be "No winner due to a tie"
