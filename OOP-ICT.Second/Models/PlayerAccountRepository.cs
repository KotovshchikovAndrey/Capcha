using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models;

public class PlayerAccountRepository : IPlayerAccountRepository
{
    private readonly Dictionary<Guid, PlayerAccount> _playerAccounts = new Dictionary<Guid, PlayerAccount>();

    public PlayerAccount FindPlayerAccountByPlayerUuid(Guid playerUuid)
    {
        if (!_playerAccounts.ContainsKey(playerUuid))
        {
            throw PlayerAccountRepositoryException.PlayerAccountDoesNotExists("Player account does not exists!");
        }
        
        var playerAccount = _playerAccounts[playerUuid];
        return playerAccount;
    }

    public Guid SavePlayerAccount(Guid playerUuid, PlayerAccount playerAccount)
    {
        if (_playerAccounts.ContainsKey(playerUuid))
        {
            throw PlayerAccountRepositoryException.PlayerAccountAlreadyExists("Player account already exists!");
        }
        
        _playerAccounts.Add(playerUuid, playerAccount);
        return playerUuid;
    }
}