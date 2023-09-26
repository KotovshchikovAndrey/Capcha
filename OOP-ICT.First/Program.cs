using OOP_ICT.Models;

var cardDeckFactory = new CardDeckFactory();
var perfectShuffle = new PerfectShuffle();

var dealer = new Dealer(perfectShuffle, cardDeckFactory);
var deckOfCards = dealer.GetDeckOfCards();

foreach (var card in deckOfCards)
{
    Console.WriteLine("card" + "=>" + "{" +
                      $"Assert.Equal(CardSuit.{card.Suit}, card.Suit);\n    Assert.Equal(CardValue.{card.Value}, card.Value);" +
                      "},");
}

