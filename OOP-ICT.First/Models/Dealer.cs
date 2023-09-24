﻿namespace OOP_ICT.Models;

public class Dealer : IDealer
{
    private readonly IReadOnlyList<ICard> _deckOfCards;
    public Dealer(ICardDeckFactory deckFactory)
    {
        var cardDeck = deckFactory.CreateCardDeck();
        _deckOfCards = cardDeck.ShuffleCards();
    }

    public IReadOnlyList<ICard> GetDeckOfCards()
    {
        return _deckOfCards;
    }
}