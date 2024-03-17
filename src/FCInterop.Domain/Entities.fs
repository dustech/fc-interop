namespace FCInterop.Domain

module Entities =

    type User =
        { Name: string
          LastName: string }
        static member instance = { Name = empty; LastName = empty }
