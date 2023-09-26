namespace OOP_ICT.Models;

public interface ICardShuffle
{
    IReadOnlyList<Card> ShuffleCards(IReadOnlyList<Card> cards);
}