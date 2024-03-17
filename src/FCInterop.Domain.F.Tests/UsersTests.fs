namespace FCInterop.Domain.F.Tests

open FCInterop.Domain.Users
open FCInterop.Domain.Entities
open FCInterop.Domain
open Xunit




type UsersTests() =

    let users =
        [ { User.instance with Name = "Alice" }
          { User.instance with Name = "Bob" }
          { User.instance with Name = "Carol" }
          { User.instance with Name = "Dave" } ]

    [<Fact>]
    member this.``Filter by single name works``() =
        let userRepo = InMemory.toQueryableUsers users
        let query = byName "Alice"

        let result = userRepo query

        Assert.Equal([ {User.instance with Name = "Alice" } ], result)
