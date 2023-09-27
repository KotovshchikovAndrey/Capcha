using OOP_ICT.Models;

var cardDeckFactory = new CardDeckFactory();
var perfectShuffleAlgorithm = new PerfectShuffleAlgorithm();

var dealer = new Dealer(cardDeckFactory, perfectShuffleAlgorithm);
dealer.ShuffleDeckOfCards();
var deckOfCards = dealer.GetCardDeck();

for (var i = 0; i < 3; i++)
{
    var card = dealer.DealCardFromDeck();
    Console.WriteLine($"{card.Suit} : {card.Value}");
}

// foreach (var card in deckOfCards)
// {
//     Console.WriteLine("card" + "=>" + "{" +
//                       $"Assert.Equal(CardSuit.{card.Suit}, card.Suit);\n    Assert.Equal(CardValue.{card.Value}, card.Value);" +
//                       "},");
// }


// var cardDeckFactory1 = new CardDeckFactory();
// var perfectShuffle1 = new PerfectShuffle();
//
// var dealer1 = new Dealer(perfectShuffle1, cardDeckFactory1);
// var deckOfCards1 = dealer.GetDeckOfCards().ToList();
// deckOfCards1.Reverse();
// deckOfCards1.RemoveAt(0);
//
// var d1 = deckOfCards1.ToHashSet();
//
// Console.WriteLine(d1.SetEquals(deckOfCards));
