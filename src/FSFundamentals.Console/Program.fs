namespace FSFundamentals.Console.Transaction

module Main =
    
    open Driver.UserConsole
    
    [<EntryPoint>]
    let main argv =

        printfn "Hello from the transaction processor!"
        
        run()
        
        printfn "Bye!"
        0
