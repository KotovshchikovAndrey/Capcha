namespace OOP_ICT.Models;

public interface ICardDeck
{
   IReadOnlyList<Card> UnpackCards();
}