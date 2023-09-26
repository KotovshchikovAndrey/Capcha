namespace OOP_ICT.Models;

public class PerfectShuffle : ICardShuffle
{
    public IReadOnlyList<Card> ShuffleCards(IReadOnlyList<Card> cards)
    {
        var half = cards.Count / 2;
        var shuffledCards = new Card[cards.Count];
        for (var i = 0; i < half; i++)
        {
            shuffledCards[i * 2] = cards[i + half];
            shuffledCards[i * 2 + 1] = cards[i];
        }

        return shuffledCards.AsReadOnly();
    }
}