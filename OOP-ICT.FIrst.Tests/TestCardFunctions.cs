using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestCardFunctions
{
    private readonly CardSuit[] _cardSuits = Enum.GetValues<CardSuit>();
    private readonly CardValue[] _cardValues = Enum.GetValues<CardValue>();
    private readonly Card[] _shuffledCards =
    {
        new Card(CardSuit.Spades, CardValue.Eight),
        new Card(CardSuit.Hearts, CardValue.Ace),
        new Card(CardSuit.Diamonds, CardValue.Eight),
        new Card(CardSuit.Clubs, CardValue.Ace),
        new Card(CardSuit.Hearts, CardValue.Seven),
        new Card(CardSuit.Spades, CardValue.Ace),
        new Card(CardSuit.Clubs, CardValue.Seven),
        new Card(CardSuit.Diamonds, CardValue.Ace),
        new Card(CardSuit.Spades, CardValue.Seven),
        new Card(CardSuit.Hearts, CardValue.King),
        new Card(CardSuit.Diamonds, CardValue.Seven),
        new Card(CardSuit.Clubs, CardValue.King),
        new Card(CardSuit.Hearts, CardValue.Six),
        new Card(CardSuit.Spades, CardValue.King),
        new Card(CardSuit.Clubs, CardValue.Six),
        new Card(CardSuit.Diamonds, CardValue.King),
        new Card(CardSuit.Spades, CardValue.Six),
        new Card(CardSuit.Hearts, CardValue.Queen),
        new Card(CardSuit.Diamonds, CardValue.Six),
        new Card(CardSuit.Clubs, CardValue.Queen),
        new Card(CardSuit.Hearts, CardValue.Five),
        new Card(CardSuit.Spades, CardValue.Queen),
        new Card(CardSuit.Clubs, CardValue.Five),
        new Card(CardSuit.Diamonds, CardValue.Queen),
        new Card(CardSuit.Spades, CardValue.Five),
        new Card(CardSuit.Hearts, CardValue.Jack),
        new Card(CardSuit.Diamonds, CardValue.Five),
        new Card(CardSuit.Clubs, CardValue.Jack),
        new Card(CardSuit.Hearts, CardValue.Four),
        new Card(CardSuit.Spades, CardValue.Jack),
        new Card(CardSuit.Clubs, CardValue.Four),
        new Card(CardSuit.Diamonds, CardValue.Jack),
        new Card(CardSuit.Spades, CardValue.Four),
        new Card(CardSuit.Hearts, CardValue.Ten),
        new Card(CardSuit.Diamonds, CardValue.Four),
        new Card(CardSuit.Clubs, CardValue.Ten),
        new Card(CardSuit.Hearts, CardValue.Three),
        new Card(CardSuit.Spades, CardValue.Ten),
        new Card(CardSuit.Clubs, CardValue.Three),
        new Card(CardSuit.Diamonds, CardValue.Ten),
        new Card(CardSuit.Spades, CardValue.Three),
        new Card(CardSuit.Hearts, CardValue.Nine),
        new Card(CardSuit.Diamonds, CardValue.Three),
        new Card(CardSuit.Clubs, CardValue.Nine),
        new Card(CardSuit.Hearts, CardValue.Two),
        new Card(CardSuit.Spades, CardValue.Nine),
        new Card(CardSuit.Clubs, CardValue.Two),
        new Card(CardSuit.Diamonds, CardValue.Nine),
        new Card(CardSuit.Spades, CardValue.Two),
        new Card(CardSuit.Hearts, CardValue.Eight),
        new Card(CardSuit.Diamonds, CardValue.Two),
        new Card(CardSuit.Clubs, CardValue.Eight)
    };

    [Fact]
    public void IsCardsInRightOrder_InputIsCardValuesAndSuits_ReturnTrue()
    {
        var cardsInRightOrder = new List<Card>();
        foreach (var value in _cardValues.Reverse())
        {
            foreach (var suit in _cardSuits)
            {
                var card = new Card(suit, value);
                cardsInRightOrder.Add(card);
            } 
        }

        var cardDeckFactory = new PerfectShuffledCardDeckFactory();
        var cardDeck = cardDeckFactory.CreateCardDeck();
        var deckOfCards = cardDeck.GetCardsInOriginalOrder();
        for (var i = 0; i < 52; i++)
        {
            var expectedCard = cardsInRightOrder[i];
            var actualCard = deckOfCards[i];
            
            var isSuitsEqual = expectedCard.Suit == actualCard.Suit;
            var isValuesEqual = expectedCard.Value == actualCard.Value;
            
            Assert.True(isSuitsEqual && isValuesEqual);
        }
    }

    [Fact]
    public void IsDeckOfCardsLengthEqual52_InputIsDeckOfCardsCount_ReturnTrue()
    {
        var cardDeckFactory = new PerfectShuffledCardDeckFactory();
        var dealer = new Dealer(cardDeckFactory);
        var deckOfCards = dealer.GetDeckOfCards();
        
        Assert.Equal(52, deckOfCards.Count);
    }

    [Fact]
    public void IsDeckOfCardsShuffled_InputIsCardValuesAndSuits_ReturnTrue()
    {
        var cardDeckFactory = new PerfectShuffledCardDeckFactory();
        var dealer = new Dealer(cardDeckFactory);
        var deckOfCards = dealer.GetDeckOfCards();

        for (var i = 0; i < 52; i++)
        {
            var expectedCard = _shuffledCards[i];
            var actualCard = deckOfCards[i];

            var isSuitsEqual = expectedCard.Suit == actualCard.Suit;
            var isValuesEqual = expectedCard.Value == actualCard.Value;
            
            Assert.True(isSuitsEqual && isValuesEqual);
        }
    }
}