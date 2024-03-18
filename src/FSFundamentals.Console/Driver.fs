module FSFundamentals.Console.Transaction.Driver

module UserConsole =
    
    open System
    
    let private promptUser () =
        printf "(d)eposit, (w)ithdraw or e(x)it: "
        Console.ReadKey().KeyChar

    let private getAmount () =
        printf "Enter the amount of the transaction: "
        Console.ReadLine() |> Decimal.Parse
    
    let userLoop () =
        
        let mutable balance = 0m

        let mutable running = true

        while running do
            
            printfn "Balance: %A" balance
            
            let action = promptUser()
            printfn "\nYou told me to do this: %A" action
            
            balance <- match action with
                        | 'd' -> balance + getAmount()
                        | 'w' -> balance - getAmount()
                        | _ -> running <- action <> 'x'
                               balance
                    


