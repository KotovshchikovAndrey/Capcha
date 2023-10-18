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

var classicBlackjackFactory = new ClassicBlackjackCreator();
var classicBlackjack = classicBlackjackFactory
    .SetDealer()
    .AddPlayerInGame(player1)
    .AddPlayerInGame(player2)
    .CreateGame(casinoBank);

classicBlackjack.StartGame();
classicBlackjack.HandOutCards();

classicBlackjack.DealAdditionalCardForPlayer(player1.Uuid);
Console.WriteLine(classicBlackjack.GetPlayerCards(player1.Uuid)[0].Value);
Console.WriteLine(classicBlackjack.GetPlayerCards(player1.Uuid)[1].Value);
Console.WriteLine(classicBlackjack.GetPlayerCards(player1.Uuid)[2].Value);
Console.WriteLine(classicBlackjack.CalculateCardsSum(classicBlackjack.GetPlayerCards(player1.Uuid)));




