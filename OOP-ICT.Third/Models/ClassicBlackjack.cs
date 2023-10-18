using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Third.Abstractions;
using OOP_ICT.Third.Dto;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjack : CasinoCardGame<ClassicBlackjackPlayer, ClassicBlackjackDealer>
{
    public ClassicBlackjack(
        ICasinoBank casinoBank, 
        Dictionary<Guid, ClassicBlackjackPlayer> players,
        ClassicBlackjackDealer dealer
        ) : base(casinoBank, players, dealer) {}
    
    public override void StartGame()
    {
        if (Players.Count == 0)
        {
            throw CardGameException.NotEnoughPlayersForStart("Game cannot be started while player count is 0!");
        }
        
        Dealer.ModelInstance.ShuffleCardDeck();
        IsGameActive = true;
    }

    public override void FinishGame()
    {
        PlayDealer();
        IsGameActive = false;
    }
    
    public override void HandOutCards()
    {
        foreach (var player in Players.Values)
        {
            var playerInitialCards = new List<Card>();
            for (var i = 0; i < 2; i++)
            {
                var card = Dealer.ModelInstance.DealCard();
                playerInitialCards.Add(card);
            }
            
            player.SetInitialCards(playerInitialCards);
        }

        var dealerInitialCards = new List<Card> { Dealer.ModelInstance.DealCard() };
        Dealer.SetInitialCards(dealerInitialCards);
    }

    public override void RemovePlayerFromGame(Guid playerUuid) => Players.Remove(playerUuid);

    public override void DealAdditionalCardForPlayer(Guid playerUuid)
    {
        var playerCardsSum = CalculateCardsSum(GetPlayerCards(playerUuid));
        Console.WriteLine(playerCardsSum);
        if (playerCardsSum > 21)
        {
            throw CardGameException.PlayerIsLostGame("Player is lost game! The number of points is more than 21!");
        }
        
        var playerInGame = FindPLayerInGame(playerUuid);
        var card = Dealer.ModelInstance.DealCard();
        playerInGame.AddCard(card);
    }

    public override void IncreasePlayerBet(Guid playerUuid, decimal bet)
    {
        if (IsGameActive)
        {
            throw CardGameException.GameIsActive("You cannot increase the bet after the start of the game!");
        }
        
        var playerInGame = FindPLayerInGame(playerUuid);
        var isPlayerBalanceSufficient = CasinoBank.CheckIsPlayerCasinoBalanceSufficient(playerUuid, bet);
        if (!isPlayerBalanceSufficient)
        {
            throw CardGameException.BalanceIsNotSufficientForBet("Balance is not sufficient for bet!");
        }
        
        playerInGame.IncreaseCurrentBet(bet);
    }

    public override decimal AddWinningAmount(Guid playerUuid)
    {
        var playerBet = GetPlayerBet(playerUuid);
        CasinoBank.AddChipsToPlayerCasinoBalance(playerUuid, playerBet);
        return playerBet;
    }

    public override decimal SubtractLossAmount(Guid playerUuid)
    {
        var playerBet = GetPlayerBet(playerUuid);
        CasinoBank.SubtractChipsFromPlayerCasinoBalance(playerUuid, playerBet);
        return playerBet;
    }

    public override IReadOnlyList<Card> GetPlayerCards(Guid playerUuid)
    {
        var playerInGame = FindPLayerInGame(playerUuid);
        return playerInGame.GetCards();
    }

    public override decimal GetPlayerBet(Guid playerUuid)
    {
        var playerInGame = FindPLayerInGame(playerUuid);
        return playerInGame.CurrentBet;
    }
    
    public decimal AddBlackjackAmount(Guid playerUuid) 
    { 
        var playerBet = GetPlayerBet(playerUuid);
        var blackjackAmount = playerBet * Constants.BlackjackWinningRatio;
        CasinoBank.AddChipsToPlayerCasinoBalance(playerUuid, blackjackAmount);

        return blackjackAmount;
    }
    
    public bool CheckIsPlayerHasBlackjack(Guid playerUuid)
    {
        var playerInGame = FindPLayerInGame(playerUuid);
        var playerCards = playerInGame.GetCards();

        return (playerCards.Count == 2)
               && (
                   (playerCards[0].Value is CardValue.Ace &&
                    Constants.ClassicBlackjackCardPoints[playerCards[1].Value] == 10)
                   ||
                   (playerCards[1].Value is CardValue.Ace &&
                    Constants.ClassicBlackjackCardPoints[playerCards[0].Value] == 10)
               );
    }
    
    public int CalculateCardsSum(IReadOnlyList<Card> cards) 
    { 
        var cardsSum = cards
            .Where(card => card.Value is not CardValue.Ace)
            .Sum(card => Constants.ClassicBlackjackCardPoints[card.Value]);
        
        foreach (var card in cards) 
        { 
            if (card.Value is not CardValue.Ace) continue; 
            var acePoints = Constants.ClassicBlackjackCardPoints[card.Value];
            if (cardsSum + acePoints > 21)
            {
                cardsSum += 1;
            }
            else
            {
                cardsSum += acePoints;
            }
        }

        return cardsSum;
    }
    
    public PlayerGameResult CalculateGameResultForPlayer(Guid playerUuid)
    {
        if (IsGameActive)
        {
            throw CardGameException.GameIsActive("The game is not finish yet!");
        }

        var playerInGame = FindPLayerInGame(playerUuid);
        var playerCardsSum = CalculateCardsSum(GetPlayerCards(playerInGame.ModelInstance.Uuid));
        if (playerCardsSum > 21) return CalculateLoseResult(playerInGame);
        
        var dealerCardsSum = CalculateCardsSum(Dealer.GetCards());
        if (dealerCardsSum > 21 || playerCardsSum > dealerCardsSum) return CalculateWinResult(playerInGame);

        return playerCardsSum < dealerCardsSum
            ? CalculateLoseResult(playerInGame)
            : CalculateDrawResult(playerInGame);
    }

    private void PlayDealer()
    {
        var dealerCards = Dealer.GetCards();
        var dealerCardsSum = CalculateCardsSum(dealerCards); 
        while (dealerCardsSum < 21)
        {
            DealAdditionalCardForDealer();
            dealerCardsSum = CalculateCardsSum(dealerCards);
            if (dealerCardsSum > 17)
            {
                break;
            }
        }
    }
    
    private void DealAdditionalCardForDealer()
    {
        var card = Dealer.ModelInstance.DealCard();
        Dealer.AddCard(card);
    }
    
    private ClassicBlackjackPlayer FindPLayerInGame(Guid playerUuid)
    {
        if (!Players.ContainsKey(playerUuid))
        {
            throw CardGameException.PlayerDoesNotExists("Player in game does not exists!");
        }

        return Players[playerUuid];
    }

    private PlayerGameResult CalculateWinResult(ClassicBlackjackPlayer playerInGame)
    {
        var playerGameResult = new PlayerGameResult(playerInGame.ModelInstance, playerInGame.GetCards());
        var playerBet = GetPlayerBet(playerInGame.ModelInstance.Uuid);
        CasinoBank.AddChipsToPlayerCasinoBalance(playerInGame.ModelInstance.Uuid, playerBet);
        playerGameResult.WinAmount = playerBet;
        
        return playerGameResult;
    }

    private PlayerGameResult CalculateLoseResult(ClassicBlackjackPlayer playerInGame)
    {
        var playerGameResult = new PlayerGameResult(playerInGame.ModelInstance, playerInGame.GetCards());
        var playerBet = GetPlayerBet(playerInGame.ModelInstance.Uuid);
        CasinoBank.SubtractChipsFromPlayerCasinoBalance(playerInGame.ModelInstance.Uuid, playerBet);
        playerGameResult.LoseAmount = playerBet;

        return playerGameResult;
    }

    private PlayerGameResult CalculateDrawResult(ClassicBlackjackPlayer playerInGame)
    {
        var playerGameResult = new PlayerGameResult(playerInGame.ModelInstance, playerInGame.GetCards());
        return playerGameResult;
    }
}