open System

[<EntryPoint>]
let main argv = 
    


    printfn "Hello from the transaction processor!"

    printf "(d)eposit, (w)ithdraw or e(x)it: "

    let action = Console.ReadLine()

    printfn "You have selected %A" action

    printfn "Bye!"
    0