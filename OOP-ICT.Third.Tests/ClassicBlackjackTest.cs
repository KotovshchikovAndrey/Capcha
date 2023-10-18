using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Third.Enum;
using OOP_ICT.Third.Exceptions;
using OOP_ICT.Third.Models;
using Xunit;

namespace OOP_ICT.Third.Tests;

public class ClassicBlackjackTest
{
    private ICasinoBank _casinoBank;
    private ClassicBlackjackCreator _classicBlackjackCreator;
    private ClassicBlackjack _classicBlackjack;
    private Player _testPlayerInGame;
    
    public ClassicBlackjackTest() => PrepareInitialData();
    
    [Fact]
    public void TestCalculateCardSumMethod()
    {
        var cards = new List<Card>
        {
            new Card(CardSuit.Diamonds, CardValue.King),
            new Card(CardSuit.Clubs, CardValue.Three),
            new Card(CardSuit.Hearts, CardValue.Seven),
        };

        var cardSum = _classicBlackjack.CalculateCardsSum(cards);
        Assert.Equal(20, cardSum);
        
        cards.Add(new Card(CardSuit.Spades, CardValue.Ace));
        cardSum = _classicBlackjack.CalculateCardsSum(cards);
        Assert.Equal(21, cardSum);
        
        // Remove King ( -10 points )
        cards.RemoveAt(0);
        cardSum = _classicBlackjack.CalculateCardsSum(cards);
        Assert.Equal(21, cardSum);
    }

    [Fact]
    public void TestDealAdditionalCardForPlayerMethod()
    {
        var playerCards = _classicBlackjack.GetPlayerCards(_testPlayerInGame.Uuid);
        var cardSum = _classicBlackjack.CalculateCardsSum(playerCards);
        Assert.Equal(0, cardSum);

        while (cardSum <= 21)
        {
            _classicBlackjack.DealAdditionalCardForPlayer(_testPlayerInGame.Uuid);
            cardSum = _classicBlackjack.CalculateCardsSum(playerCards);
        }

        var exception = Assert.Throws<CardGameException>(
            () => _classicBlackjack.DealAdditionalCardForPlayer(_testPlayerInGame.Uuid));
        
        Assert.Equal("Player is lost game! The number of points is more than 21!", exception.Message);
    }

    [Fact]
    public void TestIncreasePlayerBetMethod()
    {
        _classicBlackjack.IncreasePlayerBet(_testPlayerInGame.Uuid, 999);
        var info = _casinoBank.GetPlayerCasinoAccountInfo(_testPlayerInGame.Uuid);
        Assert.Equal(1000, info.Balance);
        
        _classicBlackjack.IncreasePlayerBet(_testPlayerInGame.Uuid, 1);
        Assert.Equal(1000, _classicBlackjack.GetPlayerBet(_testPlayerInGame.Uuid));
        
        var exception = Assert.Throws<CardGameException>(
            ()=> _classicBlackjack.IncreasePlayerBet(_testPlayerInGame.Uuid,1));
        
        Assert.Equal("Balance is not sufficient for bet!", exception.Message);
    }

    [Fact]
    public void TestStartGameMethod()
    {
        _classicBlackjack.StartGame();
        Assert.True(_classicBlackjack.IsGameActive);
        
        var exception = Assert.Throws<CardGameException>(
            ()=> _classicBlackjack.IncreasePlayerBet(_testPlayerInGame.Uuid,1));
        
        Assert.Equal("You cannot increase the bet after the start of the game!", exception.Message);

        exception = Assert.Throws<CardGameException>(
            () => _classicBlackjack.HandOutCards());
        
        Assert.Equal("It is not possible to deal cards after the start of the game!", exception.Message);
    }

    [Fact]
    public void TestFinishGameMethod()
    {
        var dealerCards = _classicBlackjack.GetDealerCards();
        Assert.Empty(dealerCards);
        
        _classicBlackjack.FinishGame();
        Assert.False(_classicBlackjack.IsGameActive);

        dealerCards = _classicBlackjack.GetDealerCards();
        Assert.True(dealerCards.Count > 0);
    }

    [Fact]
    public void TestCalculateGameResultForPlayerMethod()
    {
        _classicBlackjack.HandOutCards();
        _classicBlackjack.StartGame();

        var playerCards = _classicBlackjack.GetPlayerCards(_testPlayerInGame.Uuid);
        var playerCardSum = _classicBlackjack.CalculateCardsSum(playerCards);
        while (playerCardSum <= 21)
        {
            _classicBlackjack.DealAdditionalCardForPlayer(_testPlayerInGame.Uuid);
            playerCards = _classicBlackjack.GetPlayerCards(_testPlayerInGame.Uuid);
            playerCardSum = _classicBlackjack.CalculateCardsSum(playerCards);
        }

        var exception = Assert.Throws<CardGameException>(
            () => _classicBlackjack.CalculateGameResultForPlayer(_testPlayerInGame.Uuid));
        
        Assert.Equal("The game is not finish yet!", exception.Message);
        
        _classicBlackjack.FinishGame();
        var gameResult = _classicBlackjack.CalculateGameResultForPlayer(_testPlayerInGame.Uuid);
        Assert.Equal(GameResultStatus.Defeat, gameResult.ResultStatus);
    }

    private void PrepareInitialData()
    {
        var bankFactory = new BaseBankFactory(); 
        var moneyBank = bankFactory.CreateMoneyBank();
        _casinoBank = bankFactory.CreateCasinoBank(moneyBank);

        var player1 = new Player("Andrey", "Kot");
        var player2 = new Player("Denis", "York");
        var player3 = new Player("Denis", "York");
        _testPlayerInGame = player1;

        _casinoBank.CreateNewCasinoAccountForPlayer(player1);
        _casinoBank.CreateNewCasinoAccountForPlayer(player2);
        _casinoBank.CreateNewCasinoAccountForPlayer(player3);

        _casinoBank.AddChipsToPlayerCasinoBalance(player1.Uuid, 1000);
        _casinoBank.AddChipsToPlayerCasinoBalance(player2.Uuid, 2000);
        _casinoBank.AddChipsToPlayerCasinoBalance(player2.Uuid, 3000);

        _classicBlackjackCreator  = new ClassicBlackjackCreator();
        _classicBlackjack = _classicBlackjackCreator
            .SetDealer()
            .AddPlayerInGame(player1)
            .AddPlayerInGame(player2)
            .CreateGame(_casinoBank);
    }
}