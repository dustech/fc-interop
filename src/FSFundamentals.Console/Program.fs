open System

let promptUser () =
    printf "(d)eposit, (w)ithdraw or e(x)it: "
    Console.ReadLine()

let getAmount () = 10m

[<EntryPoint>]
let main argv =

    printfn "Hello from the transaction processor!"

    let mutable balance = 0m

    let mutable running = true

    while running do
        
        printfn "Balance: %A" balance
        
        let action = promptUser ()
        printfn "You told me to do this: %A" action
        
        balance <- match action with
                    | "d" -> balance + getAmount()
                    | "w" -> balance - getAmount()
                    | "x" -> running <- false
                             balance
                    | _ -> balance
        
        

    printfn "Bye!"
    0
