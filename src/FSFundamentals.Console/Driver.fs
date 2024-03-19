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
        
        let rec loop balance = 
            printfn $"Balance: %A{balance}"            
            let action = promptUser()
            printfn $"\nYou told me to do this: %A{action}"            
            match action with
                | 'd' -> loop <| balance + getAmount()
                | 'w' -> loop <| balance - getAmount()
                | 'x' -> ()
                | _ -> loop balance
        loop 0m
                    


