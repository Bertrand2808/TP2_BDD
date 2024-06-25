public class Scrutin
{
    // Variables pour affecter les votes des candidats et les votes blancs
    public int countCandiate1 { get; set; }
    public int countCandiate2 { get; set; }
    public int countCandiate3 { get; set; }
    public int countWhiteVotes { get; set; }
    
    // Variables pour stocker le nombre total de votes, le gagnant.
    public int totalVotes { get; set; }
    public string winner { get; set; }
    
    // Variables pour stocker les candidates et les votes du second tour
    public string secondRoundCandidate1 { get; set; }
    public string secondRoundCandidate2 { get; set; }
    public int secondRoundCountCandidate1 { get; set; }
    public int secondRoundCountCandidate2 { get; set; }
    public int countWhiteVotesSecondRound { get; set; }
    
    // Variable pour stocker le numéro du tour
    public int round { get; set; }
    
    public static void Main()
    {
        RunTestScenarios();
    }
    
    // Méthode pour ouvrir le scrutin
    public void OpenPoll()
    {
        if (round < 2)
        {
            Console.WriteLine("The poll is open.");
            round++;
        }
    }

    // Méthode pour déterminer le gagnant du premier tour
    public void GetWinnerOfFirstRound()
    {
        totalVotes = countCandiate1 + countCandiate2 + countCandiate3 + countWhiteVotes;
        if (countCandiate1 > totalVotes / 2)
        {
            winner = "Candidate 1";
        }
        else if (countCandiate2 > totalVotes / 2)
        {
            winner = "Candidate 2";
        }
        else if (countCandiate3 > totalVotes / 2)
        {
            winner = "Candidate 3";
        }
        else
        {
            winner = "No winner";
        }
    }
    
    // Méthode pour déterminer le gagnant du second tour
    public void GetWinnerOfSecondRound()
    {
        totalVotes = secondRoundCountCandidate1 + secondRoundCountCandidate2 + countWhiteVotesSecondRound;
        List<KeyValuePair<string, int>> candidates = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("Candidate 1", secondRoundCountCandidate1),
            new KeyValuePair<string, int>("Candidate 2", secondRoundCountCandidate2)
        };
        candidates.Sort((x, y) => y.Value.CompareTo(x.Value));
        if (candidates[0].Value == candidates[1].Value)
        {
            winner = "No winner due to a tie";
        }
        else
        {
            winner = candidates[0].Key;
        }
    }
    
    // Méthode pour déterminer les candidats du second tour
    public void DetermineSecondRoundCandidates()
    {
        double percentageCandidate1 = (double)countCandiate1 / totalVotes * 100;
        double percentageCandidate2 = (double)countCandiate2 / totalVotes * 100;
        double percentageCandidate3 = (double)countCandiate3 / totalVotes * 100;
        
        if (percentageCandidate1 <= 50 && percentageCandidate2 <= 50 && percentageCandidate3 <= 50)
        {
            List<KeyValuePair<string, double>> candidates = new List<KeyValuePair<string, double>>
            {
                new KeyValuePair<string, double>("Candidate 1", percentageCandidate1),
                new KeyValuePair<string, double>("Candidate 2", percentageCandidate2),
                new KeyValuePair<string, double>("Candidate 3", percentageCandidate3)
            };
            candidates.Sort((x, y) => y.Value.CompareTo(x.Value));
            secondRoundCandidate1 = candidates[0].Key;
            secondRoundCandidate2 = candidates[1].Key;
        }
    }
    
    // Méthode pour afficher le nombre de votes et le pourcentage pour chaque candidat
    public void DisplayVoteCountAndPercentage()
    {
        double percentageCandidate1 = (double)countCandiate1 / totalVotes * 100;
        double percentageCandidate2 = (double)countCandiate2 / totalVotes * 100;
        double percentageCandidate3 = (double)countCandiate3 / totalVotes * 100;
        double percentageWhiteVotes = (double)countWhiteVotes / totalVotes * 100;

        Console.WriteLine($"Candidate 1: {countCandiate1} votes ({percentageCandidate1}% of total votes)");
        Console.WriteLine($"Candidate 2: {countCandiate2} votes ({percentageCandidate2}% of total votes)");
        Console.WriteLine($"Candidate 3: {countCandiate3} votes ({percentageCandidate3}% of total votes)");
        Console.WriteLine($"White Votes: {countWhiteVotes} votes ({percentageWhiteVotes}% of total votes)");
    }
    
    // Méthode pour exécuter les scénarios de test
    public static void RunTestScenarios()
    {
        // Test scenario pour le premier tour
        Scrutin scrutin = new Scrutin();
        scrutin.OpenPoll();
        scrutin.countCandiate1 = 35;
        scrutin.countCandiate2 = 15;
        scrutin.countCandiate3 = 10;
        scrutin.countWhiteVotes = 0;
        scrutin.GetWinnerOfFirstRound();
        Console.WriteLine($"Winner: {scrutin.winner}");
        scrutin.DisplayVoteCountAndPercentage();
        
        // Test scenario pour le second tour
        scrutin = new Scrutin();
        scrutin.OpenPoll();
        scrutin.countCandiate1 = 30;
        scrutin.countCandiate2 = 35;
        scrutin.countCandiate3 = 40;
        scrutin.countWhiteVotes = 0;
        scrutin.GetWinnerOfFirstRound();
        Console.WriteLine($"Winner: {scrutin.winner}");
        scrutin.DetermineSecondRoundCandidates();
        scrutin.DisplayVoteCountAndPercentage();
        scrutin.OpenPoll();
        scrutin.secondRoundCountCandidate1 = 40;
        scrutin.secondRoundCountCandidate2 = 60;
        scrutin.countWhiteVotesSecondRound = 0;
        scrutin.GetWinnerOfSecondRound();
        Console.WriteLine($"Winner: {scrutin.winner}");
        
        // Scenario 3: égalité au second tour
        scrutin = new Scrutin();
        scrutin.OpenPoll();
        scrutin.countCandiate1 = 25;
        scrutin.countCandiate2 = 25;
        scrutin.countCandiate3 = 50;
        scrutin.countWhiteVotes = 0;
        scrutin.GetWinnerOfFirstRound();
        Console.WriteLine($"Winner: {scrutin.winner}");
        scrutin.DetermineSecondRoundCandidates();
        scrutin.DisplayVoteCountAndPercentage();
        
        scrutin.OpenPoll();
        scrutin.secondRoundCountCandidate1 = 50;
        scrutin.secondRoundCountCandidate2 = 50;
        scrutin.countWhiteVotesSecondRound = 0;
        scrutin.GetWinnerOfSecondRound();
        Console.WriteLine($"Winner: {scrutin.winner}");
        
        // Scenario 4: Test avec des votes blancs
        scrutin = new Scrutin();
        scrutin.OpenPoll();
        scrutin.countCandiate1 = 25;
        scrutin.countCandiate2 = 25;
        scrutin.countCandiate3 = 50;
        scrutin.countWhiteVotes = 10;
        scrutin.GetWinnerOfFirstRound();
        Console.WriteLine($"Winner: {scrutin.winner}");
        scrutin.DetermineSecondRoundCandidates();
        scrutin.DisplayVoteCountAndPercentage();
        
        scrutin.OpenPoll();
        scrutin.secondRoundCountCandidate1 = 50;
        scrutin.secondRoundCountCandidate2 = 50;
        scrutin.countWhiteVotesSecondRound = 10;
        scrutin.GetWinnerOfSecondRound();
        Console.WriteLine($"Winner: {scrutin.winner}");
    }
}
