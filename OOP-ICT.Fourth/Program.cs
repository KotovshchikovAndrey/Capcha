using OOP_ICT.Fourth.Models.CardCombinations;
using OOP_ICT.Models;

var cards = new List<Card>()
{
    new Card(CardSuit.Clubs, CardValue.Ace),
    new Card(CardSuit.Clubs, CardValue.Queen),
    new Card(CardSuit.Clubs, CardValue.King),
    new Card(CardSuit.Clubs, CardValue.Jack),
    new Card(CardSuit.Clubs, CardValue.Seven),
};

Console.WriteLine(new RoyalFlush().Check(cards));