namespace OOP_ICT.Models;

public class CardDeckFactory : ICardDeckFactory
{
    public ICardDeck CreateCardDeck()
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
        
        return new CardDeck(cards);
    } 
}