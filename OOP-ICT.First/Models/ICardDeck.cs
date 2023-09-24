using System.Collections.Immutable;

namespace OOP_ICT.Models;

public interface ICardDeck
{
    IReadOnlyList<ICard> ShuffleCards();
    IReadOnlyList<ICard> GetCardsInOriginalOrder();
}