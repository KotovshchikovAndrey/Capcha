using OOP_ICT.Fourth.Enum;
using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Third.Abstractions;

namespace OOP_ICT.Fourth.Abstractions;

public abstract class ChainOfCardCombination
{
    protected readonly List<ICardCombination> CardCombinations = new List<ICardCombination>();
    public abstract CombinationName GetStrongestCombination(IEnumerable<Card> cards);
}