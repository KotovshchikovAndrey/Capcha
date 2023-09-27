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

    public void ShuffleCardDeck()
    {
        var shuffleCardDeck = _cardDeckShuffleAlgorithm.ShuffleCardDeck(_cardDeck);
        _cardDeck = shuffleCardDeck;
    }

    public Card DealCard()
    {
        var card = _cardDeck.PopNextCard();
        return card;
    }

    public CardDeck GetCardDeck()
    {
        return _cardDeck;
    }
}