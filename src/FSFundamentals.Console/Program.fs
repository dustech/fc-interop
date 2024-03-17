open System

let promptUser () =
    printf "(d)eposit, (w)ithdraw or e(x)it: "
    Console.ReadLine()


[<EntryPoint>]
let main argv = 
    
    printfn "Hello from the transaction processor!"

    let mutable running = true
    while running do 
        let action = promptUser()
        printfn "You told me to do this: %A" action
        running <- action <> "x"

    printfn "Bye!"
    0