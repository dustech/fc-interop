namespace FCInterop.Domain

open FCInterop.Domain.Entities
open FCInterop.Domain.Users

module InMemory =
    let rec filter user query =
        match query with
        | ByNames names -> names |> Seq.exists (eq user.Name)

    let query (users: seq<User>) (query: Query) =
        users
        |> Seq.filter (fun user -> filter user query)

    let cmd (users: ResizeArray<User>) (cmd: Command) =
        match cmd with
        | Create us ->
            for user in us do
                users.Add(user)

            ()
            
    type Users(users: seq<User>) =
        interface IQuery<Query, User> with
            member this.query q = query users q

    let toQueryableUsers users = (query users)
    let toCommandUsers users = cmd users
    let toUsersInMemory users : IQuery<Query, User> = Users users
