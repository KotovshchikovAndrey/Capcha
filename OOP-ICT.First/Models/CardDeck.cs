namespace OOP_ICT.Models;

public class CardDeckFactory : ICardDeckFactory
{
    private readonly ICard[] _cards =
    {
        // Ace
        new HeartsAce(),
        new ClubsAce(),
        new SpadesAce(),
        new DiamondsAce(),
                
        // King
        new HeartsKing(),
        new ClubsKing(),
        new SpadesKing(),
        new DiamondsKing(),
                
        // Queen
        new HeartsQueen(),
        new ClubsQueen(),
        new SpadesQueen(),
        new DiamondsQueen(),
                
        // Jack
        new HeartsJack(),
        new ClubsJack(),
        new SpadesJack(),
        new DiamondsJack(),
                
        // Ten
        new HeartsTen(),
        new ClubsTen(),
        new SpadesTen(),
        new DiamondsTen(),
                
        // Nine
        new HeartsNine(),
        new ClubsNine(),
        new SpadesNine(),
        new DiamondsNine(),
        
        // Eight
        new HeartsEight(),
        new ClubsEight(),
        new SpadesEight(),
        new DiamondsEight(),
        
        // Seven
        new HeartsSeven(),
        new ClubsSeven(),
        new SpadesSeven(),
        new DiamondsSeven(),
        
        // Six
        new HeartsSix(),
        new ClubsSix(),
        new SpadesSix(),
        new DiamondsSix(),
        
        // Five
        new HeartsFive(),
        new ClubsFive(),
        new SpadesFive(),
        new DiamondsFive(),
        
        // Four
        new HeartsFour(),
        new ClubsFour(),
        new SpadesFour(),
        new DiamondsFour(),
        
        // Three
        new HeartsThree(),
        new ClubsThree(),
        new SpadesThree(),
        new DiamondsThree(),
        
        // Two
        new HeartsTwo(),
        new ClubsTwo(),
        new SpadesTwo(),
        new DiamondsTwo(),
    };
    
    public ICardDeck CreateCardDeck()
    {
        return new CardDeck(_cards);;
    } 
}

internal class CardDeck : ICardDeck
{
    private readonly ICard[] _cards;
    public CardDeck(ICard[] cards)
    {
        _cards = cards;
    }
    
    public IReadOnlyList<ICard> ShuffleCards()
    {
        var half =_cards.Length / 2;
        var shuffledCards = new ICard[_cards.Length];
        for (var i = 0; i < half; i++)
        {
            shuffledCards[i*2] = _cards[i + half];
            shuffledCards[i * 2 + 1] = _cards[i];
        }

        return shuffledCards.AsReadOnly();
    }

    public IReadOnlyList<ICard> GetCardsInOriginalOrder()
    {
        return _cards.AsReadOnly();
    }
}