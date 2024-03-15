namespace FCInterop.Domain

open System

module Common =
    let λ (func: Func<'a, 'b>) : 'a -> 'b = func.Invoke
    let lambda = λ

