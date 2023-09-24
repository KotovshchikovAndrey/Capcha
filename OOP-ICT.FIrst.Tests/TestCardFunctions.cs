using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestCardFunctions
{
    private readonly CardSuit[] _cardSuits = Enum.GetValues<CardSuit>();
    private readonly CardValue[] _cardValues = Enum.GetValues<CardValue>();
    private readonly ICard[] _shuffledCards =
    {
        new SpadesEight(),  
        new HeartsAce(),    
        new DiamondsEight(),
        new ClubsAce(),     
        new HeartsSeven(),  
        new SpadesAce(),    
        new ClubsSeven(),   
        new DiamondsAce(),
        new SpadesSeven(),
        new HeartsKing(),
        new DiamondsSeven(),
        new ClubsKing(),
        new HeartsSix(),
        new SpadesKing(),
        new ClubsSix(),
        new DiamondsKing(),
        new SpadesSix(),
        new HeartsQueen(),
        new DiamondsSix(),
        new ClubsQueen(),
        new HeartsFive(),
        new SpadesQueen(),
        new ClubsFive(),
        new DiamondsQueen(),
        new SpadesFive(),
        new HeartsJack(),
        new DiamondsFive(),
        new ClubsJack(),
        new HeartsFour(),
        new SpadesJack(),
        new ClubsFour(),
        new DiamondsJack(),
        new SpadesFour(),
        new HeartsTen(),
        new DiamondsFour(),
        new ClubsTen(),
        new HeartsThree(),
        new SpadesTen(),
        new ClubsThree(),
        new DiamondsTen(),
        new SpadesThree(),
        new HeartsNine(),
        new DiamondsThree(),
        new ClubsNine(),
        new HeartsTwo(),
        new SpadesNine(),
        new ClubsTwo(),
        new DiamondsNine(),
        new SpadesTwo(),
        new HeartsEight(),
        new DiamondsTwo(),
        new ClubsEight()
    };

    [Fact]
    public void IsCardsInRightOrder_InputIsCardValuesAndSuits_ReturnTrue()
    {
        var cardsInRightOrder = new List<ICard>();
        foreach (var value in _cardValues.Reverse())
        {
            foreach (var suit in _cardSuits)
            {
                var card = new Card(suit, value);
                cardsInRightOrder.Add(card);
            } 
        }
        
        var cardDeckFactory = new CardDeckFactory();
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
        var cardDeckFactory = new CardDeckFactory();
        var dealer = new Dealer(cardDeckFactory);
        var deckOfCards = dealer.GetDeckOfCards();
        
        Assert.Equal(52, deckOfCards.Count);
    }

    [Fact]
    public void IsDeckOfCardsShuffled_InputIsCardValuesAndSuits_ReturnTrue()
    {
        var cardDeckFactory = new CardDeckFactory();
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