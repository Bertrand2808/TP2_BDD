namespace SpecFlowScrutin;

public class Scrutin
{
    public int countCandiate1 { get; set; }
    public int countCandiate2 { get; set; }
    public int countCandiate3 { get; set; }
    public int totalVotes { get; set; }
    public string winner { get; set; }
    public string secondRoundCandidate1 { get; set; }
    public string secondRoundCandidate2 { get; set; }
    public int secondRoundCountCandidate1 { get; set; }
    public int secondRoundCountCandidate2 { get; set; }
    public int round { get; set; }
    
    public static void Main()
    {
        Console.WriteLine("Hello, World!");
    }
    
    public void OpenPoll()
    {
        if (round < 2)
        {
            Console.WriteLine("The poll is open.");
            round++;
        }
    }

    public void GetWinnerOfFirstRound()
    {
        totalVotes = countCandiate1 + countCandiate2 + countCandiate3;
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
    
    public void GetWinnerOfSecondRound()
    {
        totalVotes = secondRoundCountCandidate1 + secondRoundCountCandidate2;
        // lister le nombre de vote et décider le vainqueur 
        List<KeyValuePair<string, int>> candidates = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("Candidate 1", secondRoundCountCandidate1),
            new KeyValuePair<string, int>("Candidate 2", secondRoundCountCandidate2)
        };
        candidates.Sort((x, y) => y.Value.CompareTo(x.Value));
        winner = candidates[0].Key;
    }
    
    public void DetermineSecondRoundCandidates()
    {
        // Calculate percentage of votes for each candidate
        double percentageCandidate1 = (double)countCandiate1 / totalVotes * 100;
        double percentageCandidate2 = (double)countCandiate2 / totalVotes * 100;
        double percentageCandidate3 = (double)countCandiate3 / totalVotes * 100;
        
        // if no candidate has more than 50% of the votes, the top two candidates go to a second round
        if (percentageCandidate1 <= 50 && percentageCandidate2 <= 50 && percentageCandidate3 <= 50)
        {
            // List the top two candidates
            List<KeyValuePair<string, double>> candidates = new List<KeyValuePair<string, double>>
            {
                new KeyValuePair<string, double > ("Candidate 1", percentageCandidate1),
                new KeyValuePair<string, double > ("Candidate 2", percentageCandidate2),
                new KeyValuePair<string, double > ("Candidate 3", percentageCandidate3)
            };
            candidates.Sort((x, y) => y.Value.CompareTo(x.Value));
            secondRoundCandidate1 = candidates[0].Key;
            secondRoundCandidate2 = candidates[1].Key;
        }
    }
    
    public void DisplayVoteCountAndPercentage()
    {
        // Calculate the percentage of votes for each candidate
        double percentageCandidate1 = (double)countCandiate1 / totalVotes * 100;
        double percentageCandidate2 = (double)countCandiate2 / totalVotes * 100;
        double percentageCandidate3 = (double)countCandiate3 / totalVotes * 100;

        // Print the number of votes and the percentage for each candidate
        Console.WriteLine($"Candidate 1: {countCandiate1} votes ({percentageCandidate1}% of total votes)");
        Console.WriteLine($"Candidate 2: {countCandiate2} votes ({percentageCandidate2}% of total votes)");
        Console.WriteLine($"Candidate 3: {countCandiate3} votes ({percentageCandidate3}% of total votes)");
    }
}