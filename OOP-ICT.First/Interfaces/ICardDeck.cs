namespace OOP_ICT.Models;

public interface ICardDeck
{
   Card PopCard();
   IReadOnlyList<Card> GetCards();
}
