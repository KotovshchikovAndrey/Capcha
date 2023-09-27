namespace OOP_ICT.Models;

public interface IDealer
{
    void ShuffleCardDeck();
    Card DealCard();
    CardDeck GetCardDeck();
}