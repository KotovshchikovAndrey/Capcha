namespace OOP_ICT.Models;

public class Dealer : IDealer
{
    private readonly IReadOnlyList<Card> _deckOfCards;
    public Dealer(ICardDeckFactory deckFactory)
    {
        var cardDeck = deckFactory.CreateCardDeck();
        _deckOfCards = cardDeck.ShuffleCards();
    }

    public IReadOnlyList<Card> GetDeckOfCards()
    {
        return _deckOfCards;
    }
}