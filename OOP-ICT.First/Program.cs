using OOP_ICT.Models;

var cardDeckFactory = new CardDeckFactory();
var dealer = new Dealer(cardDeckFactory);
var deckOfCards = dealer.GetDeckOfCards();

foreach (var card in deckOfCards)
{
    Console.WriteLine($"{card.Suit} : {card.Value}");
}
