using Xunit;

namespace SpecFlowScrutin.Specs.Steps;

[Binding]
public sealed class ScrutinStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    private Scrutin _scrutin;
    private int _round = 0;
    
    public ScrutinStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("the poll is open")]
    public void GivenThePollIsOpen()
    {
        _scrutin = new Scrutin();
        _scrutin.OpenPoll();
        _round++;
    }
    
    [Given("the votes are (.*), (.*), (.*)")]
    public void GivenTheVotesAre(int candidate1, int candidate2, int candidate3)
    {
        _scrutin.countCandiate1 = candidate1;
        _scrutin.countCandiate2 = candidate2;
        _scrutin.countCandiate3 = candidate3;
    }
    
    [When("the poll of the first round is close")]
    public void WhenTheVotesAreCounted()
    {
        _scrutin.GetWinnerOfFirstRound();
    }
    
    [Then("the winner should be (.*)")]
    public void ThenTheWinnerShouldBe(string winner)
    {
        Assert.Equal(winner, _scrutin.winner);
    }
    
    [Then("the vote count and percentage for each candidate should be displayed")]
    public void ThenTheVoteCountAndPercentageForEachCandidateShouldBeDisplayed()
    {
        _scrutin.DisplayVoteCountAndPercentage();
    }
    
    [Then("there should be a second round")]
    public void ThenThereShouldBeASecondRound()
    {
        _scrutin.DetermineSecondRoundCandidates();
        Assert.NotNull(_scrutin.secondRoundCandidate1);
        Assert.NotNull(_scrutin.secondRoundCandidate2);
    }
    
    [Given("the poll is open for the second round")]
    public void GivenThePollIsOpenForTheSecondRound()
    {
        _scrutin.OpenPoll();
        _round++;
        Assert.Equal(2, _scrutin.round);
    }
    
    [Given("the votes for the second round are (.*), (.*)")]
    public void GivenTheVotesForTheSecondRoundAre(int candidate1, int candidate2)
    {
        _scrutin.secondRoundCountCandidate1 = candidate1;
        _scrutin.secondRoundCountCandidate2 = candidate2;
    }
    
    [When("the poll of the second round is close")]
    public void WhenTheVotesForTheSecondRoundAreCounted()
    {
        _scrutin.GetWinnerOfSecondRound();
    }
}