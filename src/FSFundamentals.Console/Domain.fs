module FSFundamentals.Console.Transaction.Domain

module Account = 
    type Account = { Id: int; Balance: decimal }
    let create id balance = { Id = id; Balance = balance }
    let instance = create 0 0m
