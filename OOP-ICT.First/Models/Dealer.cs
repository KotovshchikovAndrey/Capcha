namespace OOP_ICT.Models;

public class Dealer : IDealer
{
    private CardDeck _cardDeck;
    private readonly ICardDeckShuffleAlgorithm _cardDeckShuffleAlgorithm;
    public Dealer(ICardDeckFactory deckFactory, ICardDeckShuffleAlgorithm cardDeckShuffleAlgorithm)
    {
        _cardDeck = deckFactory.CreateCardDeck();
        _cardDeckShuffleAlgorithm = cardDeckShuffleAlgorithm;
    }

    public void ShuffleDeckOfCards()
    {
        var shuffleCardDeck = _cardDeckShuffleAlgorithm.ShuffleCardDeck(_cardDeck);
        _cardDeck = shuffleCardDeck;
    }

    public Card DealCardFromDeck()
    {
        var card = _cardDeck.PopCard();
        return card;
    }

    public IReadOnlyList<Card> GetDeckOfCards()
    {
        var deckOfCards = _cardDeck.GetCards();
        return deckOfCards;
    }
}