module FSFundamentals.Console.Transaction.Rules


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
    
    let applyTransaction account amount transaction =
        {
            account with
                Balance = account.Balance + amount
                Transactions = account.Transactions @ [transaction] 
        }        
    
    let deposit amount account =
        let newTransaction = Transaction.deposit (nextTransactionId account) amount
        applyTransaction account amount newTransaction

    let withdraw amount account =
        let newTransaction = Transaction.withdraw (nextTransactionId account) amount
        applyTransaction account -amount newTransaction
