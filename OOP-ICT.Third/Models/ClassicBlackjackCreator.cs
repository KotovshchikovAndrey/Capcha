using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Third.Abstractions;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjackCreator 
    : CasinoCardGameCreator
    <
        ClassicBlackjack, 
        ClassicBlackjackPlayer, 
        ClassicBlackjackDealer
    >
{
    private ClassicBlackjackDealer _dealer;
    private readonly Dictionary<Guid, ClassicBlackjackPlayer> _players = new Dictionary<Guid, ClassicBlackjackPlayer>();
    
    public override CasinoCardGameCreator
        <
            ClassicBlackjack, 
            ClassicBlackjackPlayer, 
            ClassicBlackjackDealer
        > 
        SetDealer() 
    {
        var cardDeckFactory = new CardDeckFactory();
        var shuffleAlgorithm = new PerfectShuffleAlgorithm();
        var dealer = new Dealer(cardDeckFactory, shuffleAlgorithm);
        var classicBlackjackDealer = new ClassicBlackjackDealer(dealer);

        _dealer = classicBlackjackDealer;
        return this;
    }

    public override CasinoCardGameCreator
        <
            ClassicBlackjack, 
            ClassicBlackjackPlayer, 
            ClassicBlackjackDealer
        > 
        AddPlayerInGame(Player player)
    {
        var classicBlackjackPlayer = new ClassicBlackjackPlayer(player);
        _players.Add(player.Uuid, classicBlackjackPlayer);
        return this;
    }

    public override ClassicBlackjack CreateGame(ICasinoBank casinoBank)
    {
        var classicBlackjack = new ClassicBlackjack(casinoBank, _players, _dealer);
        return classicBlackjack;
    }
}