using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Third.Abstractions;

public abstract class CasinoCardGameCreator<T, TP, TD> 
    where T : CasinoCardGame<TP, TD> 
    where TP : CasinoCardPlayer<Player>, ICanPlaceBet
    where TD : CasinoCardPlayer<IDealer>
{
    public abstract CasinoCardGameCreator<T, TP, TD> SetDealer();
    public abstract CasinoCardGameCreator<T, TP, TD> AddPlayerInGame(Player player);
    public abstract T CreateGame(ICasinoBank casinoBank);
}