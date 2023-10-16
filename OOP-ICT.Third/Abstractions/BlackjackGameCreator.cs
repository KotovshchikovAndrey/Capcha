using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Third.Abstractions;

public abstract class BlackjackGameCreator
{
    public abstract BlackjackGameCreator SetDealer();
    public abstract BlackjackGameCreator SetCasinoManager(ICasinoBank casinoBank);
    public abstract BlackjackGameCreator AddPlayer(Player player, decimal bet);
    public abstract BlackjackGame CreateGame();
}