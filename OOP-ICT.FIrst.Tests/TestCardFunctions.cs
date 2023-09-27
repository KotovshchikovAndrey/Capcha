using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestCardFunctions
{
    [Fact]
    public void IsCardDeckLengthEqual52_InputIsListOfCardsCount_ReturnTrue()
    {
        var cardDeckFactory = new CardDeckFactory();
        var cardDeck = cardDeckFactory.CreateCardDeck();
        
        Assert.Equal(52, cardDeck.Count);
    }

    [Fact]
    public void IsCardsInRightOrder_InputIsListOfCards_ReturnTrue()
    {
        var cardDeckFactory = new CardDeckFactory();
        var cardDeck = cardDeckFactory.CreateCardDeck();
        var cards = cardDeck.GetCards();

        Assert.Collection(
            cards,
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Ace, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Ace, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Ace, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Ace, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.King, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.King, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.King, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.King, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Queen, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Queen, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Queen, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Queen, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Jack, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Jack, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Jack, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Jack, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Ten, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Ten, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Ten, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Ten, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Nine, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Nine, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Nine, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Nine, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Eight, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Eight, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Eight, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Eight, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Seven, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Seven, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Seven, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Seven, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Six, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Six, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Six, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Six, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Five, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Five, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Five, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Five, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Four, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Four, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Four, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Four, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Three, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Three, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Three, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Three, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Two, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Two, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Two, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Two, card.Value);
            }

        );
    }

    [Fact]
    public void IsDeckOfCardsShuffledWithPerfectShuffle_InputIsListOfCards_ReturnTrue()
    {
        var cardDeckFactory = new CardDeckFactory();
        var perfectShuffleAlgorithm = new PerfectShuffleAlgorithm();

        var dealer = new Dealer(cardDeckFactory, perfectShuffleAlgorithm);
        dealer.ShuffleDeckOfCards();
        var deckOfCards = dealer.GetDeckOfCards();

        Assert.Collection(deckOfCards,
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Eight, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Ace, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Eight, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Ace, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Seven, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Ace, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Seven, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Ace, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Seven, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.King, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Seven, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.King, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Six, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.King, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Six, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.King, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Six, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Queen, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Six, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Queen, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Five, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Queen, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Five, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Queen, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Five, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Jack, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Five, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Jack, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Four, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Jack, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Four, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Jack, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Four, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Ten, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Four, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Ten, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Three, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Ten, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Three, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Ten, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Three, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Nine, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Three, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Nine, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Two, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Nine, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Two, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Nine, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Spades, card.Suit);
                Assert.Equal(CardValue.Two, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Hearts, card.Suit);
                Assert.Equal(CardValue.Eight, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Diamonds, card.Suit);
                Assert.Equal(CardValue.Two, card.Value);
            },
            card =>
            {
                Assert.Equal(CardSuit.Clubs, card.Suit);
                Assert.Equal(CardValue.Eight, card.Value);
            }
        );
    }
}