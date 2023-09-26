namespace OOP_ICT.Models;

public class Dealer : IDealer
{
    private readonly ICardShuffle _cardShuffle;
    private readonly ICardDeck _cardDeck;
    public Dealer(ICardShuffle cardShuffle, ICardDeckFactory deckFactory)
    {
        _cardShuffle = cardShuffle;
        _cardDeck = deckFactory.CreateCardDeck();
    }

    public IReadOnlyList<Card> GetDeckOfCards()
    {
        var deckOfCards = _cardDeck.UnpackCards();
        var shuffledDeckOfCards = _cardShuffle.ShuffleCards(deckOfCards);
        return shuffledDeckOfCards;
    }
}