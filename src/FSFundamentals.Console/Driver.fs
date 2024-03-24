module FSFundamentals.Console.Transaction.Driver




module UserConsole =

    open System
    open Domain.Account
    open Rules.Accounts

    let private promptUser () =
        printf "(d)eposit, (w)ithdraw or e(x)it: "
        Console.ReadKey().KeyChar

    let private getAmount () =
        printf "Enter the amount of the transaction: "
        // Console.ReadLine() |> Decimal.Parse
        let input = Console.ReadLine()
        let (canParse, value) = input |> Decimal.TryParse
        match canParse with
        | true -> Ok value
        | false -> Error $"Parse of amount failed: {input}"
        
        
        
    let run () =

        let rec loop account =
            printfn $"Balance: %A{account.Balance}"
            let action = promptUser ()
            printfn $"\nYou told me to do this: %A{action}"

            match action with
            | 'd' | 'w' ->
                match getAmount() with
                | Ok amount ->
                    match action with
                    | 'd' -> (amount, account) ||> deposit |> loop
                    | 'w' -> (amount, account) ||> withdraw |> loop
                    | _ -> loop account
                | Error e ->
                    printfn $"%A{e}"
                    loop account
            | 'x' -> ()
            | _ ->
                printfn $"Invalid input {action}"
                loop account

        loop instance
        ()

module Utils =
    open System.IO
    open Repository.Account
    let deleteAccountRepoFiles () =
        Directory.GetFiles(accountDataDirectory, "account_*.json") |> Array.iter File.Delete 

module AccountRepoDriver =
    open FSFundamentals.Console.Transaction.Domain
    open Rules.Accounts
    open Utils.Railway
    let run() =
        
        Utils.deleteAccountRepoFiles()
        
        
        Account.instance
        |> deposit 100m
        |> withdraw 25m
        |> Repository.Account.put 
        |> ignore

        // get an existing and non-existing account
        Repository.Account.get 0 |> printfn "%A"
        Repository.Account.get 1 |> printfn "%A"

        // modify get and put to return a Result<Account, string>

        // get and update an existing account
        Repository.Account.get 0 
        >>> deposit 40m
        >>= Repository.Account.put
        |> ignore

        // check that on reload it is a new balance
        Repository.Account.get 0 |> printfn "%A" 

        // railway flows this error right through
        Repository.Account.get 1
        >>> deposit 40m
        >>= Repository.Account.put
        |> printfn "%A"