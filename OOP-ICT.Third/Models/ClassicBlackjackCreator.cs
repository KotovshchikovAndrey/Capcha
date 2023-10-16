using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Abstractions;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjackCreator : BlackjackGameCreator
{
    private ClassicBlackjackDealer _dealer;
    private ICasinoManager _casinoManager;
    private readonly List<BlackjackPlayer> _players = new List<BlackjackPlayer>();
    
    public override BlackjackGameCreator SetDealer()
    {
        var cardDeckFactory = new CardDeckFactory();
        var shuffleAlgorithm = new PerfectShuffleAlgorithm();
        var dealer = new Dealer(cardDeckFactory, shuffleAlgorithm);

        var initialCards = new List<Card> { dealer.DealCard() };
        var classicBlackjackDealer = new ClassicBlackjackDealer(dealer, initialCards);
        
        _dealer = classicBlackjackDealer;
        return this;
    }

    public override BlackjackGameCreator SetCasinoManager(ICasinoBank casinoBank)
    {
        var classicBlackjackManager = new ClassicBlackjackManager(casinoBank, _dealer);
        _casinoManager = classicBlackjackManager;
        return this;
    }

    public override BlackjackGameCreator AddPlayer(Player player, decimal bet)
    {
        var blackjackPlayer = new BlackjackPlayer(player);
        blackjackPlayer.IncreaseCurrentBet(bet);
        _players.Add(blackjackPlayer);

        return this;
    }

    public override BlackjackGame CreateGame()
    {
        _dealer.Dealer.ShuffleCardDeck();
        var blackjackGame = new ClassicBlackjack(_casinoManager, _players);
        return blackjackGame;
    }
}