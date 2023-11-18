namespace OOP_ICT.Fourth.Dto;

public class ClassicPokerOptions
{
    public decimal MinStartBet;
    public ushort CirclesCount;

    public ClassicPokerOptions(decimal minStartBet, ushort circlesCount = 1)
    {
        MinStartBet = minStartBet;
        CirclesCount = circlesCount;
    }
}