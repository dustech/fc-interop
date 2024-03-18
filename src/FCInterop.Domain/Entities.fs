namespace FCInterop.Domain.Entities

open FCInterop.Domain


type User =
    { Name: string
      LastName: string }
    static member instance = { Name = empty; LastName = empty }
