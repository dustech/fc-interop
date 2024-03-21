module FSFundamentals.Console.Transaction.Driver

open FSFundamentals.Console.Transaction.Domain

module UserConsole =

    open System

    let private promptUser () =
        printf "(d)eposit, (w)ithdraw or e(x)it: "
        Console.ReadKey().KeyChar

    let private getAmount () =
        printf "Enter the amount of the transaction: "
        Console.ReadLine() |> Decimal.Parse

    let run () =

        let rec loop account =
            printfn $"Balance: %A{account.Balance}"
            let action = promptUser ()
            printfn $"\nYou told me to do this: %A{action}"

            match action with
            | 'd' ->
                (account, getAmount ())
                ||> Account.deposit
                |> loop
            | 'w' ->
                (account, getAmount ())
                ||> Account.withdraw
                |> loop
            | 'x' -> ()
            | _ -> loop account

        loop Account.instance
        ()
