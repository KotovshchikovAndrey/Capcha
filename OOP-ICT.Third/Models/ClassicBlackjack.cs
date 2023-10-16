using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Abstractions;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjack : BlackjackGame
{
    public ClassicBlackjack(ICasinoManager casinoManager) : base(casinoManager) {}

    public override void StartGame(List<BlackjackPlayer> players)
    {
        if (players.Count == 0)
        {
            throw new Exception("Game cannot start while players count is 0!");
        }
        
        foreach (var blackjackPlayer in players)
        {
            var playerInstance = blackjackPlayer.Player;
            CasinoManager.AddPlayerInGame(playerInstance);
            CasinoManager.IncreasePlayerBet(playerInstance.Uuid, blackjackPlayer.CurrentBet);
            
            var isPlayerHasBlackjack = CheckIsPlayerHasBlackjack(playerInstance.Uuid);
            if (!isPlayerHasBlackjack) continue;
            
            AddBlackjackAmount(playerInstance.Uuid);
            RemovePlayerFromGame(playerInstance.Uuid);
        }
    }

    public override void FinishGame()
    {
        PlayDealer();
        CalculateGameResult();
    }

    public override void AddPlayerInGame(Player player, decimal bet)
    {
        CasinoManager.AddPlayerInGame(player);
        CasinoManager.IncreasePlayerBet(player.Uuid, bet);
    }

    public override void RemovePlayerFromGame(Guid playerUuid)
    {
        SubtractLossAmount(playerUuid);
        CasinoManager.RemovePlayerFromGame(playerUuid);
    }

    public override void DealAdditionalCardForPlayer(Guid playerUuid)
    {
        CasinoManager.DealCardForPlayer(playerUuid);
    }

    public override void DealAdditionalCardForDealer()
    {
        CasinoManager.DealCardForDealer();
    }
    
    public override IReadOnlyList<Card> GetMyCards(Guid myUuid)
    {
        var playerCards = CasinoManager.GetPlayerCards(myUuid);
        return playerCards;
    }
    
    private void AddBlackjackAmount(Guid playerUuid)
    {
        var playerBet = CasinoManager.GetPLayerBet(playerUuid);
        CasinoManager.AddChipsToPlayerBalance(
            playerUuid, playerBet * Constants.BlackjackWinningRatio);
    }
    private void AddWinningAmount(Guid playerUuid)
    {
        var playerBet = CasinoManager.GetPLayerBet(playerUuid);
        CasinoManager.AddChipsToPlayerBalance(playerUuid, playerBet);
    }

    private void SubtractLossAmount(Guid playerUuid)
    {
        var playerBet = CasinoManager.GetPLayerBet(playerUuid);
        CasinoManager.SubtractChipsFromPlayerBalance(playerUuid, playerBet);
    }

    private bool CheckIsPlayerHasBlackjack(Guid playerUuid)
    {
        var playerCards = CasinoManager.GetPlayerCards(playerUuid);
        return (playerCards.Count == 2)
               && (
                   (playerCards[0].Value is CardValue.Ace &&
                    Constants.ClassicBlackjackCardPoints[playerCards[1].Value] == 10)
                   ||
                   (playerCards[1].Value is CardValue.Ace &&
                    Constants.ClassicBlackjackCardPoints[playerCards[0].Value] == 10)
               );
    }

    private void PlayDealer()
    {
        var dealerCards = CasinoManager.GetDealerCards();
        var dealerCardsSum = CalculateCardsSum(dealerCards);
        while (dealerCardsSum is > 17 and < 21)
        {
            CasinoManager.DealCardForDealer();
            dealerCardsSum = CalculateCardsSum(dealerCards);
        }
    }
    
    private int CalculateCardsSum(IReadOnlyList<Card> cards)
    {
        var cardsSum = cards
            .Where(card => card.Value is not CardValue.Ace)
            .Sum(card => Constants.ClassicBlackjackCardPoints[card.Value]);
        
        foreach (var card in cards)
        {
            if (card.Value is not CardValue.Ace)
            {
                continue;
            }
            
            var acePoints = Constants.ClassicBlackjackCardPoints[card.Value];
            if (cardsSum + acePoints > 21)
            {
                cardsSum += 1;
            }
        }

        return cardsSum;
    }

    private void CalculateGameResult()
    {
        var dealerCardsSum = CalculateCardsSum(CasinoManager.GetDealerCards());
        var playersInGame = CasinoManager.FindAllPlayersInGame();
        foreach (var player in playersInGame)
        {
            var playerCards = CasinoManager.GetPlayerCards(player.Uuid);
            var playerCardsSum = CalculateCardsSum(playerCards);
    
            if (playerCardsSum > 21 || playerCardsSum < dealerCardsSum)
            {
                SubtractLossAmount(player.Uuid);
            } 
            
            else if (playerCardsSum > dealerCardsSum)
            {
                AddWinningAmount(player.Uuid);
            }
        }
    }
}