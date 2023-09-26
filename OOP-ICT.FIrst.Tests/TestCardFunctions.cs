using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestCardFunctions
{
    private readonly CardSuit[] _cardSuits = Enum.GetValues<CardSuit>();
    private readonly CardValue[] _cardValues = Enum.GetValues<CardValue>();
    
    [Fact]
    public void IsDeckOfCardsLengthEqual52_InputIsListOfCardsCount_ReturnTrue()
    {
        var cardDeckFactory = new CardDeckFactory();
        var cardDeck = cardDeckFactory.CreateCardDeck();
        var deckOfCards = cardDeck.UnpackCards();
        
        Assert.Equal(52, deckOfCards.Count);
    }

    [Fact]
    public void IsCardsInRightOrder_InputIsListOfCards_ReturnTrue()
    {
        var cardDeckFactory = new CardDeckFactory();
        var cardDeck = cardDeckFactory.CreateCardDeck();
        var cards = cardDeck.UnpackCards();

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
    public void IsCardsShuffledWithPerfectShuffle_InputIsListOfCards_ReturnTrue()
    {
        var cardDeckFactory = new CardDeckFactory();
        var perfectShuffle = new PerfectShuffle();

        var dealer = new Dealer(perfectShuffle, cardDeckFactory);
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