# Scrutin API

## Description

Ce projet est une API permettant de désigner le vainqueur d'un scrutin majoritaire. Il a été développé en suivant les principes du développement piloté par les tests (BDD) avec SpecFlow pour .NET.

## Fonctionnalités

- Déterminer le vainqueur du premier tour si un candidat obtient plus de 50% des voix.
- Afficher le nombre de votes et le pourcentage pour chaque candidat.
- Gérer les égalités entre les candidats.
- Gérer les votes blancs.
- Organiser un deuxième tour de scrutin si nécessaire.
- Déterminer le vainqueur du deuxième tour ou déclarer une égalité si nécessaire.

## Critères d'acceptance

1. Pour obtenir un vainqueur, le scrutin doit être clôturé.
2. Si un candidat obtient plus de 50% des voix, il est déclaré vainqueur du scrutin.
3. Afficher le nombre de votes pour chaque candidat et le pourcentage correspondant à la clôture du scrutin.
4. Si aucun candidat n'a plus de 50%, alors on garde les 2 candidats avec les meilleurs pourcentages pour un deuxième tour.
5. Il ne peut y avoir que deux tours de scrutins maximum.
6. Sur le dernier tour de scrutin, le vainqueur est le candidat ayant le pourcentage de vote le plus élevé.
7. En cas d'égalité lors du dernier tour, il n'y a pas de vainqueur.

## Installation

1. Clonez le dépôt.
   ```bash
   git clone https://github.com/Bertrand2808/TP2_BDD
    ```
2. Ouvrez le projet dans Visual Studio ou JetBrains Rider.
3. Restaurez les packages NuGet.
    ```bash
    dotnet restore
    ```
4. Construisez le projet.
    ```bash
    dotnet build
    ```
5. Exécutez les tests.
    ```bash
    dotnet test
    ```
6. Exécutez l'application.

Le projet inclut une méthode Main qui simule différents scénarios de test. Vous pouvez exécuter le projet en tant qu'application console pour voir les résultats des tests :

```bash
dotnet run
```

## Scénatio des tests

### Scénario 1: Un candidat obtient plus de 50% des voix

```gherkin
Scenario: A candidate with more than 50% of the votes is declared the winner
  Given the poll is open
  And the votes are 35, 15, 10
  When the poll of the first round is close
  Then the winner should be Candidate 1
```

### Scénario 2: Afficher le nombre de votes et le pourcentage pour chaque candidat

```gherkin
Scenario: Display the vote count and percentage for each candidate
  Given the poll is open
  And the votes are 35, 15, 10
  When the poll of the first round is close
  Then the winner should be Candidate 1
  And the vote count and percentage for each candidate should be displayed
```

### Scénario 3: Deuxième tour si aucun candidat n'a plus de 50% des voix

```gherkin
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
```

### Scénario 4: Gérer les égalités entre les candidats

  ```gherkin
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
```

### Scénario 5: Gérer les votes blancs

```gherkin
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
```

## Tests

Résultat du lancement des tests :

![alt text](image.png)
