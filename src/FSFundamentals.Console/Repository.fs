module FSFundamentals.Console.Transaction.Repository

module Account =
    open System.IO
    open Utils.Json.Serialization
    open Domain.Account
    
    let accountDataDirectory = "account-data"
    let private getAccountFileName accountId =
        Path.Combine(accountDataDirectory,$"account_{accountId}.json")

    let private getAccountData accountId =
        getAccountFileName accountId |> File.ReadAllText

    let private buildAccount json : Account=
        json |> deserialize

    let private save account =
        (getAccountFileName account.Id, serialize account)
        |> File.WriteAllText

    let get (accountId:int) : Account =
        accountId |> getAccountData |> buildAccount

    let put account =
        account |> save
        account