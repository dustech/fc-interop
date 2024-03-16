namespace FCInterop.Domain

open System
open FCInterop.Domain.Entities



module Users =
    type Filter =
        | ByNames of seq<string>
        | ByLastnames of seq<string>
        | ByPredicate of (User -> bool)
    let byName value = ByNames [ value ]
    let byNames values = ByNames values
    let byLastName value = ByLastnames [ value ]
    let byLastNames values = ByLastnames values
    let byPredicate predicate = ByPredicate predicate

    type IUser =
        inherit seq<User>
        abstract filter: seq<Filter> -> seq<User>
        abstract filter: Filter -> seq<User>

    type UsersInMemory(users: seq<User>) =
        interface IUser with
            member _.GetEnumerator() = users.GetEnumerator()
            member this.GetEnumerator() =
                (this :> seq<User>).GetEnumerator() :> System.Collections.IEnumerator

            member this.filter filters =

                let eq (a: string) (b: string) =
                    String.Equals(a, b, StringComparison.OrdinalIgnoreCase)

                let rec filter user query =
                    match query with
                    | ByNames names -> names |> Seq.exists (eq user.Name)
                    | ByLastnames lastNames -> lastNames |> Seq.exists (eq user.LastName)
                    | ByPredicate f -> f user


                users
                |> Seq.filter (fun user ->
                    filters
                    |> Seq.fold (fun take query -> take && (filter user query)) true)

            member this.filter filter = [ filter ] |> (this :> IUser).filter

    let toUsersInMemory users : IUser = UsersInMemory users



module UsersFu =
    type UserFu = {
        Name : string
    }
    type Query = | ByNames of seq<string>    
    type Command = | Insert of seq<UserFu>
    
    //type Operation = 
    let byName value = ByNames [ value ]
    let byNames = ByNames
    let insert cmd = Insert [cmd]
    let insertMany = Insert
        
    let eq (a: string) (b: string) =
                    String.Equals(a, b, StringComparison.OrdinalIgnoreCase)
    let rec filter user query =
        match query with
        | ByNames names -> names |> Seq.exists (eq user.Name)
    let query (users:seq<UserFu>) (query:Query) =
        users
        |> Seq.filter (fun user -> filter user query)
    
    let cmd (users: ResizeArray<UserFu>) (cmd: Command) =
        match cmd with
        | Insert us ->
            for user in us do
                users.Add(user)
            ()                   
        
    let toQueryableUsers users = query users
    let toCommandUsers users = cmd users