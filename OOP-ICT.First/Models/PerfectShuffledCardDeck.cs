namespace OOP_ICT.Models;

public class PerfectShuffledCardDeckFactory : ICardDeckFactory
{
    public CardDeck CreateCardDeck()
    {
        var cardSuits = Enum.GetValues<CardSuit>();
        var cardValues = Enum.GetValues<CardValue>();
        var cards = new List<Card>();
        foreach (var value in cardValues.Reverse())
        {
            foreach (var suit in cardSuits)
            {
                var card = new Card(suit, value);
                cards.Add(card);
            } 
        }
        
        return new PerfectShuffledCardDeck(cards);
    } 
}

internal class PerfectShuffledCardDeck : CardDeck
{
    public PerfectShuffledCardDeck(List<Card> cards) : base(cards)
    {
    }
    
    public override IReadOnlyList<Card> ShuffleCards()
    {
        var half =Cards.Count / 2;
        var shuffledCards = new Card[Cards.Count];
        for (var i = 0; i < half; i++)
        {
            shuffledCards[i * 2] = Cards[i + half];
            shuffledCards[i * 2 + 1] = Cards[i];
        }

        return shuffledCards.AsReadOnly();
    }
}