module FSFundamentals.Console.Transaction.Domain

module Transaction =
    type TransactionType =
        | Deposit
        | Withdraw
    type Transaction =
        { Id: int
          Type: TransactionType
          Amount: decimal }
    let create id transactionType amount =
        { Id = id
          Type = transactionType
          Amount = amount }
    let deposit id amount = create id Deposit amount 
    let withdraw id amount = create id Withdraw amount
    
module Account =
    open Transaction
    type Account = { Id: int; Balance: decimal ; Transactions: Transaction list}
    let create id balance transactions = { Id = id; Balance = balance; Transactions = transactions }
    let instance = create 0 0m []
