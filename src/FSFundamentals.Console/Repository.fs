module FSFundamentals.Console.Transaction.Repository



module Account =
    open System.IO
    open Utils.Json.Serialization
    open Domain.Account
    open Utils.Railway
    
    let accountDataDirectory = "account-data"
    let private getAccountFileName accountId =
        Path.Combine(accountDataDirectory,$"account_{accountId}.json")

    let private getAccountData accountId =
        try
            getAccountFileName accountId |> File.ReadAllText |> Ok
        with
            e -> Error e.Message

    let private buildAccount json : Result<Account,string> =
        try
            json |> deserialize |> Ok
        with
            e -> Error e.Message

    let private save account =
        try
            (getAccountFileName account.Id, serialize account)
            |> File.WriteAllText
            Ok account
        with
            e -> Error e.Message

    let get (accountId:int) =
        accountId |> getAccountData >>= buildAccount
    let put account =
        account |> save
        