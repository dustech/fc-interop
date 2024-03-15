module FCInterop.Domain.UsersTests

open Xunit
open FsUnit.Xunit
open FCInterop.Domain
open FCInterop.Domain.Entities

// Sample data for testing
let users = [
    { Name = "Alice"; LastName = "Johnson" }
    { Name = "Bob"; LastName = "Smith" }
    { Name = "Carol"; LastName = "Johnson" }
    { Name = "Dave"; LastName = "Brown" }
]

type UsersTests() =

    
    // Test filtering by single name
    [<Fact>]
    member this.``Filter by single name works`` () =
        let userRepo = Users.toUsersInMemory users
        let result = userRepo.filter (Users.Filter.byName "Alice")
        Assert.Equal( [ { Name = "Alice"; LastName = "Johnson" } ] , result )
    
    // // Test filtering by multiple names
    // [<Fact>]
    // member this.``Filter by multiple names works`` () =
    //     let userRepo = Users.toUsersInMemory users
    //     let result = userRepo.filter (Users.Filter.byNames ["Alice"; "Bob"])
    //     result |> should equal [
    //         { Name = "Alice"; LastName = "Johnson" }
    //         { Name = "Bob"; LastName = "Smith" }
    //     ]
    //
    // // Test filtering by single last name
    // [<Fact>]
    // member this.``Filter by single last name works`` () =
    //     let userRepo = Users.toUsersInMemory users
    //     let result = userRepo.filter (Users.Filter.byLastName "Johnson")
    //     result |> should equal [
    //         { Name = "Alice"; LastName = "Johnson" }
    //         { Name = "Carol"; LastName = "Johnson" }
    //     ]
    //
    // // Test filtering by multiple last names
    // [<Fact>]
    // member this.``Filter by multiple last names works`` () =
    //     let userRepo = Users.toUsersInMemory users
    //     let result = userRepo.filter (Users.Filter.byLastNames ["Johnson"; "Brown"])
    //     result |> should equal [
    //         { Name = "Alice"; LastName = "Johnson" }
    //         { Name = "Carol"; LastName = "Johnson" }
    //         { Name = "Dave"; LastName = "Brown" }
    //     ]
    //
    // // Test filtering by a custom predicate
    // [<Fact>]
    // member this.``Filter by predicate works`` () =
    //     let userRepo = Users.toUsersInMemory users
    //     let result = userRepo.filter (Users.Filter.byPredicate (fun user -> user.Name.StartsWith("D")))
    //     result |> should equal [
    //         { Name = "Dave"; LastName = "Brown" }
    //     ]