namespace OOP_ICT.Models;

public class CardDeckFactory : ICardDeckFactory
{
    public CardDeck CreateCardDeck()
    {
        var cardSuits = Enum.GetValues<CardSuit>();
        var cardValues = Enum.GetValues<CardValue>();
        var cards = (from value in cardValues.Reverse() from suit in cardSuits select new Card(suit, value)).ToList();

        return new CardDeck(cards);
    } 
}