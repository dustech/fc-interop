namespace FCInterop.Domain.F.Tests

open Xunit
open FCInterop.Domain.Entities
open FCInterop.Domain.UsersSeq


type UsersSeqTests() =
    // Sample data for testing
    let users = [
        { Name = "Alice"; LastName = "Johnson" }
        { Name = "Bob"; LastName = "Smith" }
        { Name = "Carol"; LastName = "Johnson" }
        { Name = "Dave"; LastName = "Brown" }
    ]

    
    // Test filtering by single name
    [<Fact>]
    member this.``Filter by single name works`` () =
        let userRepo = toUsersInMemory users
        let result = userRepo.filter (byName "Alice")
        Assert.Equal( [ { Name = "Alice"; LastName = "Johnson" } ] , result )
    
    // Test filtering by multiple names
    [<Fact>]
    member this.``Filter by multiple names works`` () =
        let userRepo = toUsersInMemory users
        let expected = [
            { Name = "Alice"; LastName = "Johnson" }
            { Name = "Bob"; LastName = "Smith" }
        ]       
        
        let actual = userRepo.filter (byNames ["Alice"; "Bob"])
        
        Assert.Equal<seq<User>>(expected,actual)
        
        
    
    // Test filtering by single last name
    [<Fact>]
    member this.``Filter by single last name works`` () =
        let userRepo = toUsersInMemory users
        let expected = [
            { Name = "Alice"; LastName = "Johnson" }
            { Name = "Carol"; LastName = "Johnson" }
        ]
        
        let actual = userRepo.filter (byLastName "Johnson")
        
        Assert.Equal<seq<User>>(expected,actual)
    
    // // Test filtering by multiple last names
    [<Fact>]
    member this.``Filter by multiple last names works`` () =
        let userRepo = toUsersInMemory users
        let expected = [
            { Name = "Alice"; LastName = "Johnson" }
            { Name = "Carol"; LastName = "Johnson" }
            { Name = "Dave"; LastName = "Brown" }
        ]
        
        let actual = userRepo.filter (byLastNames ["Johnson"; "Brown"])
        
        Assert.Equal<seq<User>>(expected,actual)
    
    // Test filtering by a custom predicate
    [<Fact>]
    member this.``Filter by predicate works`` () =
        let userRepo = toUsersInMemory users
        let expected = [{ Name = "Dave"; LastName = "Brown" }]
        
        let actual =
            _.Name.StartsWith("D")
            |> byPredicate
            |> userRepo.filter 
        
        
        Assert.Equal<seq<User>>(expected,actual)
        