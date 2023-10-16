using OOP_ICT.Models;

namespace OOP_ICT.Third;

public class Constants
{
    public const decimal BlackjackWinningRatio = (decimal)1.5;
    public static readonly Dictionary<CardValue, int> ClassicBlackjackCardPoints = new Dictionary<CardValue, int>()
    {
        { CardValue.Ace , 11},
        { CardValue.King, 10},
        { CardValue.Queen, 10},
        { CardValue.Jack, 10},
        { CardValue.Ten, 10},
        { CardValue.Nine, 9},
        { CardValue.Eight, 8},
        { CardValue.Seven, 7},
        { CardValue.Six, 6},
        { CardValue.Five, 5},
        { CardValue.Four, 4},
        { CardValue.Three, 3},
        { CardValue.Two, 2}
    };
}