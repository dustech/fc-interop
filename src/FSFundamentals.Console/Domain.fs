module FSFundamentals.Console.Transaction.Domain.Account

type Account = { Id: int; Balance: decimal }
let create id balance = { Id = id; Balance = balance }
let instance = create 0 0m
