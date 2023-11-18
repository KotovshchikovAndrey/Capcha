using OOP_ICT.Fourth.Abstractions;
using OOP_ICT.Fourth.Enum;
using OOP_ICT.Fourth.Models.CardCombinations;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models;

public class ChainOfPokerCardCombinations : ChainOfCardCombination
{
    public ChainOfPokerCardCombinations()
    {
        CardCombinations.Add(new OnePair());
        CardCombinations.Add(new TwoPair());
        CardCombinations.Add(new ThreeOfKind());
        CardCombinations.Add(new Straight());
        CardCombinations.Add(new Flush());
        CardCombinations.Add(new FullHouse());
        CardCombinations.Add(new FourOfKind());
        CardCombinations.Add(new StraightFlush());
        CardCombinations.Add(new RoyalFlush());
    }

    public override CombinationName GetStrongestCombination(IEnumerable<Card> cards)
    {
        var strongestCombination = CombinationName.HighCard;
        foreach (var combination in CardCombinations.Where(combination => combination.Check(cards)))
        {
            strongestCombination = combination.Name;
        }

        return strongestCombination;
    }
}