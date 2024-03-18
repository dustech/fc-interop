module FCInterop.Domain.Entities



type User =
    { Name: string
      LastName: string }
    static member instance = { Name = empty; LastName = empty }
