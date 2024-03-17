open System

let promptUser () =
    printf "(d)eposit, (w)ithdraw or e(x)it: "
    Console.ReadLine()


[<EntryPoint>]
let main argv = 
    
    printfn "Hello from the transaction processor!"

    let action = promptUser()

    printfn "You have selected %A" action

    printfn "Bye!"
    0