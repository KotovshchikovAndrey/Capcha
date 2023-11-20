using OOP_ICT.Fourth.Dto;
using OOP_ICT.Fourth.Enum;
using OOP_ICT.Fourth.Exceptions;
using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Third.Abstractions;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Fourth.Models;

public class ClassicPoker : CasinoCardGame<ClassicPokerPlayer, ClassicPokerDealer>
{
    private decimal _totalBet = 0;
    private ushort _currentCircle = 1;
    private readonly ChainOfPokerCardCombinations _chainOfPokerCardCombinations = new();
    
    private readonly ushort _circlesCount;
    private readonly decimal _minStartBet;
    
    public ClassicPoker(
        ICasinoBank casinoBank, 
        Dictionary<Guid, ClassicPokerPlayer> players, 
        ClassicPokerDealer dealer, 
        ClassicPokerOptions options) : base(casinoBank, players, dealer)
    {
        _minStartBet = options.MinStartBet;
        _circlesCount = options.CirclesCount;
    }

    public override void StartGame()
    {
        if (Players.Count < Constants.MinPlayerCountForStart)
        {
            throw CardGameException.NotEnoughPlayersForStart(
                $"Classic poker must have {Constants.MinPlayerCountForStart} and more players for start!");
        }
        
        CheckPlayersStartBetsOrThrowException();
        ChooseDealerFromPlayers();
        SetTotalBet();
        
        IsGameActive = true;
    }

    public override void FinishGame()
    {
        if (_currentCircle != _circlesCount)
        {
            throw CardGameException.GameIsActive("Last circle is not finish!");
        }
        
        IsGameActive = false;
    }

    public override void HandOutCards()
    {
        if (IsGameActive)
        {
            throw CardGameException.GameIsActive("It is not possible to deal cards after the start of the game!");
        }
        
        Dealer.ModelInstance.ShuffleCardDeck();
        foreach (var player in Players.Values)
        {
            var playerCards = new List<Card>();
            for (var index = 0; index < Constants.InitialCardCountForPlayer; index++)
            {
                var card = Dealer.ModelInstance.DealCard();
                playerCards.Add(card);
            }
            
            player.SetInitialCards(playerCards);
        }
    }

    public override void RemovePlayerFromGame(Guid playerUuid) => Players.Remove(playerUuid);

    public override void DealAdditionalCardForPlayer(Guid playerUuid)
    {
        var playerInGame = FindPLayerInGame(playerUuid);
        var newCard = Dealer.ModelInstance.DealCard();
        playerInGame.AddCard(newCard);
    }

    public override void IncreasePlayerBet(Guid playerUuid, decimal betIncrease)
    {
        var playerInGame = FindPLayerInGame(playerUuid);
        var isPlayerBalanceSufficientForBet = CasinoBank.CheckIsPlayerCasinoBalanceSufficient(
            playerUuid: playerUuid,
            chipsCount: playerInGame.CurrentBet + betIncrease);
        
        if (!isPlayerBalanceSufficientForBet)
        {
            throw CardGameException.BalanceIsNotSufficientForBet("Balance is not sufficient for bet!");
        }
        
        playerInGame.IncreaseCurrentBet(betIncrease);
        _totalBet += betIncrease;
    }

    public override decimal AddWinningAmount(Guid playerUuid)
    {
        CasinoBank.AddChipsToPlayerCasinoBalance(playerUuid, _totalBet);
        return _totalBet;
    }

    public override decimal SubtractLossAmount(Guid playerUuid)
    {
        var playerBet = GetPlayerBet(playerUuid);
        CasinoBank.SubtractChipsFromPlayerCasinoBalance(playerUuid, playerBet);
        return playerBet;
    }

    public override IReadOnlyList<Card> GetDealerCards() => Dealer.PlayerInstance.GetCards();

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
    
    public void MoveNextCircle()
    {
        if (_circlesCount == _currentCircle)
        {
            throw StopIterationException.LastIteration("Last circle is over!");
        }
        
        ChooseDealerFromPlayers();
        _currentCircle += 1;
    }

    public uint GetCirclesCount() => _circlesCount;

    public void ReplaceCardsForPLayer(Guid playerUuid, List<Card> cards)
    {
        var playerInGame = FindPLayerInGame(playerUuid);
        foreach (var card in cards)
        {
            playerInGame.RemoveCard(card);
            DealAdditionalCardForPlayer(playerUuid);
        }
    }

    public CombinationName GetStrongestCardCombinationForPlayer(Guid playerUuid)
    {
        var playerInGame = FindPLayerInGame(playerUuid);
        var playerCards = playerInGame.GetCards();
        var strongestCombination = _chainOfPokerCardCombinations.GetStrongestCombination(playerCards);
        return strongestCombination;
    }

    public PokerWinner GetWinner()
    {
        if (IsGameActive)
        {
            throw CardGameException.GameIsActive("The game is not finish yet!");
        }

        var firstPlayer = Players.Values.First();
        var firstPlayerCombination = GetStrongestCardCombinationForPlayer(firstPlayer.ModelInstance.Uuid);
        var winner = new PokerWinner(
            uuid: firstPlayer.ModelInstance.Uuid,
            cardCombination: firstPlayerCombination,
            cards: firstPlayer.GetCards()
        );

        return Players.Values.Aggregate(winner, (current, player) => ChooseWinner(player, current));
    }
    
    private ClassicPokerPlayer FindPLayerInGame(Guid playerUuid)
    {
        if (!Players.ContainsKey(playerUuid))
        {
            throw CardGameException.PlayerDoesNotExists("Player in game does not exists!");
        }

        return Players[playerUuid];
    }

    private void ChooseDealerFromPlayers()
    {
        var playerList = Players.Values.ToList();
        if (_currentCircle - 1 < playerList.Count)
        {
            Dealer.PlayerInstance = playerList[_currentCircle - 1];
            return;
        }
        
        var nextDealerIndex = (playerList.Count) % (_currentCircle - 1);
        var nextDealer = playerList[nextDealerIndex];
        Dealer.PlayerInstance = nextDealer;
    }

    private void CheckPlayersStartBetsOrThrowException()
    {
        if (Players.Values.Any(player => player.CurrentBet < _minStartBet))
        {
            throw ClassicPokerException.InsufficientStartBet($"Min bet for start game is {_minStartBet}");
        }
    }

    private void SetTotalBet()
    {
        foreach (var player in Players.Values)
        {
            _totalBet += player.CurrentBet;
        }
    }

    private Card GetStrongestCard(IReadOnlyList<Card> cards)
    {
        var strongestCard = cards[0];
        foreach (var card in cards)
        {
            if (card.Value > strongestCard.Value) strongestCard = card;
        }

        return strongestCard;
    }

    private PokerWinner ChooseWinner(ClassicPokerPlayer player, PokerWinner potentialWinner)
    {
        var strongestCombination = GetStrongestCardCombinationForPlayer(player.ModelInstance.Uuid);
        if (strongestCombination > potentialWinner.CardCombination)
        {
            return new PokerWinner(
                uuid: player.ModelInstance.Uuid,
                cardCombination: strongestCombination,
                cards: player.GetCards()
            );
        }

        if (strongestCombination == potentialWinner.CardCombination)
        {
            var winnerStrongestCard = GetStrongestCard(potentialWinner.Cards);
            var playerStrongestCard = GetStrongestCard(player.GetCards());
            if (playerStrongestCard.Value > winnerStrongestCard.Value)
            {
                return new PokerWinner(
                    uuid: player.ModelInstance.Uuid,
                    cardCombination: strongestCombination,
                    cards: player.GetCards()
                );
            }
        }

        return potentialWinner;
    }
}