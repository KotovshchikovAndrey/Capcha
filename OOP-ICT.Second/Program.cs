using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;

var moneyBank = new BaseMoneyBank(new PlayerAccountRepository());
var casinoBank= new BaseCasinoBank(new PlayerAccountRepository(), moneyBank);

var player1 = new Player(name: "Andrey", surname:"Kotovshchikov");
moneyBank.CreateNewAccountForPlayer(player1);

moneyBank.AddAmountToPlayerBalance(player1.Uuid, 100);
var info = moneyBank.GetPlayerAccountInfo(player1.Uuid);
Console.WriteLine(info.AccountName);
Console.WriteLine(info.Balance);

moneyBank.SubtractAmountFromPlayerBalance(player1.Uuid, 100);
var info2 = moneyBank.GetPlayerAccountInfo(player1.Uuid);
Console.WriteLine(info2.AccountName);
Console.WriteLine(info2.Balance);
