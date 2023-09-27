namespace OOP_ICT.Models;

public class PerfectShuffleAlgorithm : ICardDeckShuffleAlgorithm
{
    public CardDeck ShuffleCardDeck(CardDeck cardDeck)
    {
        var half = cardDeck.Count / 2;
        var cards = cardDeck.GetCards();
        var shuffledCards = new Card[cardDeck.Count];
        for (var i = 0; i < half; i++)
        {
            shuffledCards[i * 2] = cards[i + half];
            shuffledCards[i * 2 + 1] = cards[i];
        }

        return new CardDeck(shuffledCards.ToList());
    }
}