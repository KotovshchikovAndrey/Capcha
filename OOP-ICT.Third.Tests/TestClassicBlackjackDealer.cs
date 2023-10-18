using OOP_ICT.Models;
using OOP_ICT.Third.Exceptions;
using OOP_ICT.Third.Models;
using Xunit;

namespace OOP_ICT.Third.Tests;

public class TestClassicBlackjackDealer
{
    private readonly ClassicBlackjackDealer _dealer;

    public TestClassicBlackjackDealer()
    {
        var cardDeckFactory = new CardDeckFactory();
        var shuffler = new PerfectShuffleAlgorithm();
        var dealerInstance = new Dealer(cardDeckFactory, shuffler);
        _dealer = new ClassicBlackjackDealer(dealerInstance);
    }
    
    [Fact]
    public void TestSetInitialCardsMethod()
    {
        var initialCards = new List<Card>
        {
            new Card(CardSuit.Clubs, CardValue.Ace),
            new Card(CardSuit.Clubs, CardValue.King),
        };
        
        var exception = Assert.Throws<CardPlayerException>(
            () => _dealer.SetInitialCards(initialCards));
        
        Assert.Equal("Initial card count must be 1!", exception.Message);
        
        initialCards.RemoveAt(0);
        _dealer.SetInitialCards(initialCards);
        Assert.Single(_dealer.GetCards());
    }
}