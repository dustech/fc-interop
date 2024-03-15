namespace FCInterop.Domain

open System
open FCInterop.Domain.Entities



module Users =
    type Filter =
        | ByNames of seq<string>
        | ByLastnames of seq<string>
        | ByPredicate of (User -> bool)
        static member byName value = ByNames [ value ]
        static member byNames values = ByNames values
        static member byLastName value = ByLastnames [ value ]
        static member byLastNames values = ByLastnames values
        static member byPredicate predicate = ByPredicate predicate

    // type IUser =
    //     inherit seq<User>
    //     abstract getUsers: UserQuery -> seq<User>

    type IUser =
        inherit seq<User>
        abstract filter: seq<Filter> -> seq<User>
        abstract filter: Filter -> seq<User>

    type UsersInMemory(users: seq<User>) =
        interface IUser with
            member _.GetEnumerator() = users.GetEnumerator()
            //(this :> seq<User>).GetEnumerator() :> System.Collections.IEnumerator
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
