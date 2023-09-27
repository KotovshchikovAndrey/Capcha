namespace OOP_ICT.Models;

public class CardDeck : ICardDeck
{
    private List<Card> _cards; 
    public CardDeck(List<Card> cards)
    {
        _cards = cards;
    }

    public Card PopCard()
    {
        if (_cards.Count == 0)
        {
            throw new Exception("Колода пуста");
        }

        var card = _cards[0];
        _cards.RemoveAt(0);
        
        return card;
    }
    
    public IReadOnlyList<Card> TakeCards()
    {
        return _cards.AsReadOnly();
    }

    public void ReturnCards(IReadOnlyList<Card> cards)
    {
        var isCardsEqualOriginalCards = CheckIsCardsEqualOriginalCards(cards);
        if (!isCardsEqualOriginalCards)
        {
            throw new Exception("Карты не совпадают с теми, что были в колоде изначально");
        }
        
        _cards = cards.ToList();
    }

    private bool CheckIsCardsEqualOriginalCards(IReadOnlyList<Card> cards)
    {
        var cardsSet = cards.ToHashSet();
        return cardsSet.SetEquals(_cards);
    }
}