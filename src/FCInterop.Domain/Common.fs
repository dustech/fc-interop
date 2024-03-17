namespace FCInterop.Domain

open System

[<AutoOpen>]
module Common =
    let λ (func: Func<'a, 'b>) : 'a -> 'b = func.Invoke
    let lambda = λ

    let eq (a: string) (b: string) =
        String.Equals(a, b, StringComparison.OrdinalIgnoreCase)

    type IQuery<'a,'b> =
        abstract query: 'a -> seq<'b>
   
    type ICommand<'a> =
        abstract ``do``: 'a -> unit