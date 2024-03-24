module FSFundamentals.Console.Transaction.Rules

open FSFundamentals.Console.Transaction.Domain.Transaction


module Accounts =
    open FSFundamentals.Console.Transaction.Domain.Account
    open FSFundamentals.Console.Transaction.Domain
    let private nextTransactionId account =
        match account.Transactions with
        | [] -> 0
        | _ ->
            account.Transactions
            |> List.map (_.Id)
            |> List.max
            |> (+) 1
    
    let applyTransaction account transaction =
        let newTransactions = account.Transactions @ [transaction]
        let newBalance =
            newTransactions
            |> List.map (fun t ->
                match t.Type with
                | Deposit -> t.Amount
                | Withdraw -> -t.Amount
                )
            |> List.sum            
            
        {
            account with
                Balance = newBalance
                Transactions = newTransactions
        }        
    
    let deposit amount account =
        let newTransaction = Transaction.deposit (nextTransactionId account) amount
        applyTransaction account newTransaction

    let withdraw amount account =
        let newTransaction = Transaction.withdraw (nextTransactionId account) amount
        applyTransaction account newTransaction
