module FCInterop.Domain.Users

open FCInterop.Domain.Entities


type Query = | ByNames of seq<string>    
type Command = | Create of seq<User>
let byName value = ByNames [ value ]
let byNames = ByNames
let create cmd = Create [cmd]
let createMany = Create
                
    
    