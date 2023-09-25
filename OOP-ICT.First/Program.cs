using OOP_ICT.Models;

var cardDeckFactory = new PerfectShuffledCardDeckFactory();
var dealer = new Dealer(cardDeckFactory);
var deckOfCards = dealer.GetDeckOfCards();

foreach (var card in deckOfCards)
{
    Console.WriteLine($"new Card(CardSuit.{card.Suit}, CardValue.{card.Value}),");
}
