namespace OOP_ICT.Models;

public class Dealer : IDealer
{
    private readonly ICardShuffle _cardShuffle;
    private readonly ICardDeck _cardDeck;
    public Dealer(ICardShuffle cardShuffle, ICardDeckFactory deckFactory)
    {
        _cardShuffle = cardShuffle;
        _cardDeck = deckFactory.CreateCardDeck();
        PrepareDeckOfCards();
    }

    public Card DealCardFromDeck()
    {
        var card = _cardDeck.PopCard();
        return card;
    }

    public IReadOnlyList<Card> GetDeckOfCards()
    {
        var deckOfCards = _cardDeck.TakeCards();
        return deckOfCards;
    }

    private void PrepareDeckOfCards()
    {
        var deckOfCards = _cardDeck.TakeCards();
        var shuffledDeckOfCards = _cardShuffle.ShuffleCards(deckOfCards);
        _cardDeck.ReturnCards(shuffledDeckOfCards);
    }
}