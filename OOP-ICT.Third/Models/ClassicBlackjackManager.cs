using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Third.Abstractions;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjackManager : ICasinoManager
{
    private readonly ICasinoBank _bank;
    private readonly ClassicBlackjackDealer _dealer;
    private readonly Dictionary<Guid, ClassicBlackjackPlayer> _players = 
        new Dictionary<Guid, ClassicBlackjackPlayer>();

    public ClassicBlackjackManager(ICasinoBank bank, ClassicBlackjackDealer dealer)
    {
        _bank = bank ?? throw CasinoManagerException.NullReference("Bank cannot be null!");
        _dealer = dealer ?? throw CasinoManagerException.NullReference("Dealer cannot be null!");
    }

    public void AddPlayerInGame(Player player)
    {
        if (_players.ContainsKey(player.Uuid))
        {
            throw CasinoManagerException.PlayerAlreadyExists("Player already in game!");
        }
        
        var newPlayer = new ClassicBlackjackPlayer(player, GetInitialCardsForPlayer());
        _players.Add(newPlayer.Player.Uuid, newPlayer);
    }

    public void RemovePlayerFromGame(Guid playerUuid)
    {
        var playerInGame = FindBlackjackPlayer(playerUuid);
        _players.Remove(playerInGame.Player.Uuid);
    }
    
    public void AddChipsToPlayerBalance(Guid playerUuid, decimal amount)
    {
        var playerInGame = FindBlackjackPlayer(playerUuid);
        _bank.AddChipsToPlayerCasinoBalance(playerInGame.Player.Uuid, amount);
    }

    public void SubtractChipsFromPlayerBalance(Guid playerUuid, decimal amount)
    {
        var playerInGame = FindBlackjackPlayer(playerUuid);
        _bank.SubtractChipsFromPlayerCasinoBalance(playerInGame.Player.Uuid, amount);
    }

    public void IncreasePlayerBet(Guid playerUuid, decimal bet)
    {
        var playerInGame = FindBlackjackPlayer(playerUuid);
        var isBalanceSufficient = _bank.CheckIsPlayerCasinoBalanceSufficient(playerUuid, 
            playerInGame.CurrentBet + bet);
        
        if (!isBalanceSufficient)
        {
            throw CasinoManagerException.BalanceIsNotSufficientForBet("Insufficient balance for bet!");
        }
        
        playerInGame.IncreaseCurrentBet(bet);
    }

    public void DealCardForPlayer(Guid playerUuid)
    {
        var playerInGame = FindBlackjackPlayer(playerUuid);
        var card = _dealer.Dealer.DealCard();
        playerInGame.AddCard(card);
    }

    public void DealCardForDealer()
    {
        var card = _dealer.Dealer.DealCard();
        _dealer.AddCard(card);
    }

    public IReadOnlyList<Card> GetPlayerCards(Guid playerUuid)
    {
        var playerInGame = FindBlackjackPlayer(playerUuid);
        return playerInGame.GetCards();
    }

    public IReadOnlyList<Card> GetDealerCards()
    {
        return _dealer.GetCards();
    }

    public decimal GetPLayerBet(Guid playerUuid)
    {
        var playerInGame = FindBlackjackPlayer(playerUuid);
        return playerInGame.CurrentBet;
    }

    private ClassicBlackjackPlayer FindBlackjackPlayer(Guid playerUuid)
    {
        if (!_players.ContainsKey(playerUuid))
        {
            throw CasinoManagerException.PlayerDoesNotExists("Player in game does not exists!");
        }

        return _players[playerUuid];
    }
    
    private List<Card> GetInitialCardsForPlayer()
    {
        var playerCards = new List<Card>();
        for (var i = 0; i < 2; i++)
        {
            var card = _dealer.Dealer.DealCard();
            playerCards.Add(card);
        }

        return playerCards;
    }
}