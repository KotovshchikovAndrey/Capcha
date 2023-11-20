using OOP_ICT.Fourth.Dto;
using OOP_ICT.Fourth.Exceptions;
using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Third.Models;
using Xunit;

namespace OOP_ICT.Fourth.Tests;

public class TestClassicPoker
{
    private ICasinoBank _casinoBank;
    private ClassicPoker _classicPoker;
    private Dictionary<Guid, ClassicPokerPlayer> _pokerPlayers;
    
    public TestClassicPoker() => PrepareInitialData();

    [Fact]
    public void TestMoveNextCircle()
    {
        SetStartBetOrPlayers();
        _classicPoker.StartGame();

        for (var i = 1; i < _classicPoker.GetCirclesCount(); i++)
        {
            _classicPoker.MoveNextCircle();
        }

        Assert.Throws<StopIterationException>(() => _classicPoker.MoveNextCircle());
    }

    [Fact]
    public void TestGetWinner()
    {
        SetStartBetOrPlayers();
        _classicPoker.HandOutCards();
        _classicPoker.StartGame();

        for (var i = 1; i < _classicPoker.GetCirclesCount(); i++)
        {
            _classicPoker.MoveNextCircle();
        }
        
        _classicPoker.FinishGame();
        var winner = _classicPoker.GetWinner();
        var chainOfPokerCardCombinations = new ChainOfPokerCardCombinations();
        Assert.True(winner.CardCombination == chainOfPokerCardCombinations.GetStrongestCombination(winner.Cards));
    }
    
    private void SetStartBetOrPlayers()
    {
        foreach (var player in _pokerPlayers.Values)
        {
            _classicPoker.IncreasePlayerBet(player.ModelInstance.Uuid, 100);
        }
    }
    
    private void PrepareInitialData()
    {
        var bankFactory = new BaseBankFactory(); 
        var moneyBank = bankFactory.CreateMoneyBank();
        _casinoBank = bankFactory.CreateCasinoBank(moneyBank);

        var player1 = new Player("Andrey", "Kot");
        var player2 = new Player("Denis", "York");
        var player3 = new Player("Denis", "York");

        _casinoBank.CreateNewCasinoAccountForPlayer(player1);
        _casinoBank.CreateNewCasinoAccountForPlayer(player2);
        _casinoBank.CreateNewCasinoAccountForPlayer(player3);

        _casinoBank.AddChipsToPlayerCasinoBalance(player1.Uuid, 1000);
        _casinoBank.AddChipsToPlayerCasinoBalance(player2.Uuid, 2000);
        _casinoBank.AddChipsToPlayerCasinoBalance(player3.Uuid, 3000);

        _pokerPlayers = new Dictionary<Guid, ClassicPokerPlayer>()
        {
            {player1.Uuid, new ClassicPokerPlayer(player1)},
            {player2.Uuid, new ClassicPokerPlayer(player2)},
            {player3.Uuid, new ClassicPokerPlayer(player3)},
        };

        var dealer = new Dealer(new CardDeckFactory(), new PerfectShuffleAlgorithm());
        _classicPoker = new ClassicPoker(
            casinoBank: _casinoBank,
            players: _pokerPlayers,
            dealer: new ClassicPokerDealer(dealer),
            options: new ClassicPokerOptions(minStartBet: 100, circlesCount: 3)
        );
    }
}