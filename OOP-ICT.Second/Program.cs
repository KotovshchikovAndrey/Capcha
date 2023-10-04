using OOP_ICT.Second.Models;
using OOP_ICT.Second.Models.PlayerBills;

var bank = new BaseBank();
var blackjackCasino = new BlackjackCasino(bank);

var usdPlayerBill = new UsdPlayerBill();
var player = new Player(usdPlayerBill, 100);

blackjackCasino.AddBlackjackAmount(player);
Console.WriteLine($"{player.PlayerBill.Balance} {player.PlayerBill.Currency}");
