namespace OOP_ICT.Models;

// Я не знаю как лучше сделать, поэтому реализовал оба варианта
// С одной стороны карты - константы, их строго 52 штуки (не больше, не меньше) и их все можно расписать вручную
// С другой стороны, можно сделать один класс Card и через конструктор передавать разные значения
public class Card : ICard
{
    public CardSuit Suit { get; }
    public CardValue Value { get; }

    public Card(CardSuit suit, CardValue value)
    {
        Suit = suit;
        Value = value;
    }
}

// Clubs Cards
public class ClubsTwo : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Two;
}

public class ClubsThree : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Three;
}

public class ClubsFour : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Four;
}

public class ClubsFive : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Five;
}

public class ClubsSix : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Six;
}

public class ClubsSeven : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Seven;
}

public class ClubsEight : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Eight;
}

public class ClubsNine : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Nine;
}

public class ClubsTen : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Ten;
}

public class ClubsJack : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Jack;
}

public class ClubsQueen : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Queen;
}

public class ClubsKing : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.King;
}

public class ClubsAce : ICard
{
    public CardSuit Suit => CardSuit.Clubs;
    public CardValue Value => CardValue.Ace;
}


// Diamonds Cards
public class DiamondsTwo : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Two;
}

public class DiamondsThree : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Three;
}

public class DiamondsFour : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Four;
}

public class DiamondsFive : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Five;
}

public class DiamondsSix : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Six;
}

public class DiamondsSeven : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Seven;
}

public class DiamondsEight : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Eight;
}

public class DiamondsNine : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Nine;
}

public class DiamondsTen : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Ten;
}

public class DiamondsJack : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Jack;
}

public class DiamondsQueen : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Queen;
}

public class DiamondsKing : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.King;
}

public class DiamondsAce : ICard
{
    public CardSuit Suit => CardSuit.Diamonds;
    public CardValue Value => CardValue.Ace;
}


// Hearts Cards
public class HeartsTwo : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Two;
}

public class HeartsThree : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Three;
}

public class HeartsFour : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Four;
}

public class HeartsFive : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Five;
}

public class HeartsSix : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Six;
}

public class HeartsSeven : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Seven;
}

public class HeartsEight : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Eight;
}

public class HeartsNine : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Nine;
}

public class HeartsTen : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Ten;
}

public class HeartsJack : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Jack;
}

public class HeartsQueen : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Queen;
}

public class HeartsKing : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.King;
}

public class HeartsAce : ICard
{
    public CardSuit Suit => CardSuit.Hearts;
    public CardValue Value => CardValue.Ace;
}


// Spades Cards
public class SpadesTwo : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Two;
}

public class SpadesThree : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Three;
}

public class SpadesFour : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Four;
}

public class SpadesFive : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Five;
}

public class SpadesSix : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Six;
}

public class SpadesSeven : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Seven;
}

public class SpadesEight : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Eight;
}

public class SpadesNine : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Nine;
}

public class SpadesTen : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Ten;
}

public class SpadesJack : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Jack;
}

public class SpadesQueen : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Queen;
}

public class SpadesKing : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.King;
}

public class SpadesAce : ICard
{
    public CardSuit Suit => CardSuit.Spades;
    public CardValue Value => CardValue.Ace;
}