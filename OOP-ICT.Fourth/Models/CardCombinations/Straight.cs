using OOP_ICT.Fourth.Abstractions;
using OOP_ICT.Fourth.Enum;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models.CardCombinations;

public class Straight : ICardCombination
{
    public CombinationName Name { get; } = CombinationName.Straight;
    
    public bool Check(IEnumerable<Card> cards)
    {
        var cardValueList = System.Enum.GetValues(typeof(CardValue)).Cast<CardValue>().ToList();
        var inputCardValueList = cards.Select(card => card.Value).OrderBy(value => value).ToList();

        var currentIndex = cardValueList.FindIndex(value => value == inputCardValueList[0]);
        foreach (var cardValue in inputCardValueList)
        {
            if (currentIndex >= cardValueList.Count || cardValue != cardValueList[currentIndex])
            {
                return false;
            }
            
            currentIndex += 1;
        }

        return true;
    }
}