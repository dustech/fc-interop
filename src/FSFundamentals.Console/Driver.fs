module FSFundamentals.Console.Transaction.Driver

open FSFundamentals.Console.Transaction.Domain.Account
open FSFundamentals.Console.Transaction.Rules.Accounts

module UserConsole =

    open System

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
