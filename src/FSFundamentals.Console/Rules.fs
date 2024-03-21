module FSFundamentals.Console.Transaction.Rules

module Accounts =
    open FSFundamentals.Console.Transaction.Domain.Account
    let deposit value account =
        { account with Balance = account.Balance + value }

    let withdraw value account =
        { account with Balance = account.Balance - value }
