using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Abstractions;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjackFactory : BlackjackFactory
{
    public override BlackjackGame CreateGame()
    {
        var cardDeckFactory = new CardDeckFactory();
        var shuffleAlgorithm = new PerfectShuffleAlgorithm();
        var dealer = new Dealer(cardDeckFactory, shuffleAlgorithm);

        var moneyAccountRepository = new PlayerAccountRepository();
        var moneyBank = new BaseMoneyBank(moneyAccountRepository);

        var casinoAccountRepository = new PlayerAccountRepository();
        var casinoBank = new BaseCasinoBank(casinoAccountRepository, moneyBank);
        
        var initialCards = new List<Card> { dealer.DealCard() };
        var classicBlackjackDealer = new ClassicBlackjackDealer(dealer, initialCards);

        var classicBlackjackManager = new ClassicBlackjackManager(casinoBank, classicBlackjackDealer);
        var classicBlackjack = new ClassicBlackjack(classicBlackjackManager);

        return classicBlackjack;
    }
}