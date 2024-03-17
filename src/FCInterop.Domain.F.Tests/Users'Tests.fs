namespace FCInterop.Domain.F.Tests

open FCInterop.Domain
open Xunit
open Users



type UsersTests() =
        
    let users = [
        { Name = "Alice" }
        { Name = "Bob"}
        { Name = "Carol"}
        { Name = "Dave" }
    ]
    
    [<Fact>]
    member this.``Filter by single name works`` () =
        let userRepo = toQueryableUsers users
        let query = byName "Alice"
        
        let result = userRepo query
        
        Assert.Equal( [ { Name = "Alice"; } ] , result )