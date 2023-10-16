using OOP_ICT.Second.Abstractions;
using OOP_ICT.Third.Models;

var bankFactory = new BaseBankFactory();

var moneyBank = bankFactory.CreateMoneyBank();
var casinoBank = bankFactory.CreateCasinoBank(moneyBank);

var player1 = new Player("Andrey", "Kot");
var player2 = new Player("Denis", "York");

moneyBank.CreateNewAccountForPlayer(player1);
moneyBank.CreateNewAccountForPlayer(player2);

moneyBank.AddAmountToPlayerBalance(player1.Uuid, 1000);
moneyBank.AddAmountToPlayerBalance(player2.Uuid, 2000);

casinoBank.CreateNewCasinoAccountForPlayer(player1);
casinoBank.CreateNewCasinoAccountForPlayer(player2);

casinoBank.AddChipsToPlayerCasinoBalance(player1.Uuid, 1000);
casinoBank.AddChipsToPlayerCasinoBalance(player2.Uuid, 2000);

var classicBlackjackCreator = new ClassicBlackjackCreator();
var classicBlackjack = classicBlackjackCreator
    .SetDealer()
    .SetCasinoManager(casinoBank)
    .AddPlayer(player1, 100)
    .AddPlayer(player2, 200)
    .CreateGame();

classicBlackjack.StartGame();
var cards1 = classicBlackjack.GetMyCards(player1.Uuid);

Console.WriteLine(cards1[0].Value);
