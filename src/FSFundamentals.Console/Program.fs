namespace FSFundamentals.Console.Transaction

module Main =
    
    open Driver.AccountRepoDriver
    
    [<EntryPoint>]
    let main argv =

        printfn "Hello from the transaction processor!"
        
        run() |> ignore
        
        printfn "Bye!"
        0
