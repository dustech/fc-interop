namespace FSFundamentals.Console.Transaction.Domain

type Account = { Id: int; Balance: decimal }

module Account =
    let create id balance = { Id = id; Balance = balance }
    let instance = create 0 0m 
    let deposit account value = { account with Balance = account.Balance + value }
    let withdraw account value = { account with Balance = account.Balance - value }
    