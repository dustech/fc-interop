namespace FSFundamentals.Console.Transaction.Rules

open FSFundamentals.Console.Transaction.Domain

module Accounts =
    let deposit value account =
        { account with Balance = account.Balance + value }

    let withdraw value account =
        { account with Balance = account.Balance - value }
