using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Exceptions;

namespace OOP_ICT.Second.Models;

public class BlackjackCasino
{
    private readonly ICasinoBank _bank;
    private readonly Dictionary<Guid, BlackjackPlayer> _blackjackPlayers = new Dictionary<Guid, BlackjackPlayer>();
    public BlackjackCasino(ICasinoBank bank)
    {
        _bank = bank;
    }

    public void AddWinningAmount(Guid playerUuid)
    {
        var blackjackPlayer = FindPLayerInGame(playerUuid);
        _bank.AddChipsToPlayerCasinoBalance(blackjackPlayer.Uuid, blackjackPlayer.CurrentBet);
    }

    public void SubtractLossAmount(Guid playerUuid)
    {
        var blackjackPlayer = FindPLayerInGame(playerUuid);
        _bank.SubtractChipsFromPlayerCasinoBalance(blackjackPlayer.Uuid, blackjackPlayer.CurrentBet);
    }

    public void AddBlackjackAmount(Guid playerUuid)
    {
        var blackjackPlayer = FindPLayerInGame(playerUuid);
        _bank.AddChipsToPlayerCasinoBalance(blackjackPlayer.Uuid,
            blackjackPlayer.CurrentBet * Constants.BlackjackWinningRatio);
    }
    
    public void AddPlayerInGame(Player player)
    {
        var newBlackjackPlayer = new BlackjackPlayer(player.Uuid, player.Name, player.Surname);
        _blackjackPlayers.Add(player.Uuid, newBlackjackPlayer);
    }

    public void IncreasePlayerBet(Guid playerUuid,int betIncrease)
    {
        var blackjackPlayer = FindPLayerInGame(playerUuid);
        var isBalanceSufficient = !_bank.CheckIsPlayerCasinoBalanceSufficient(playerUuid, betIncrease);
        if (!isBalanceSufficient)
        {
            throw BlackjackCasinoException.BalanceIsNotSufficientForBet("Недостаточно средств для ставки!");
        }

        var chips = _bank.SubtractChipsFromPlayerCasinoBalance(playerUuid, betIncrease);
        blackjackPlayer.IncreaseCurrentBet(chips);
    }

    private BlackjackPlayer FindPLayerInGame(Guid playerUuid)
    {
        if (!_blackjackPlayers.ContainsKey(playerUuid))
        {
            throw BlackjackCasinoException.PlayerDoesNotExists("Игрок не найден!");
        }

        return _blackjackPlayers[playerUuid];
    }
}