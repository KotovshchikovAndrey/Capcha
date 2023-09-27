using OOP_ICT.Models;

var cardDeckFactory = new CardDeckFactory();
var perfectShuffleAlgorithm = new PerfectShuffleAlgorithm();

var dealer = new Dealer(cardDeckFactory, perfectShuffleAlgorithm);
dealer.ShuffleCardDeck();
var deckOfCards = dealer.GetCardDeck();

for (var i = 0; i < 3; i++)
{
    var card = dealer.DealCard();
    Console.WriteLine($"{card.Suit} : {card.Value}");
}
