namespace FSFundamentals.Console.Transaction.Domain

type Account = { Id: int; Balance: decimal }

module Account =
    let create id balance = { Id = id; Balance = balance }
    let instance = create 0 0m 
    