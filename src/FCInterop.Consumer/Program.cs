using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Domain;
using Microsoft.FSharp.Core;
using static Domain.Users;
using static Domain.Commands.Filter;
using static System.Console;
using static Domain.Commands;

#pragma warning disable CA1303

var exampleUsers = new List<User>()
{
    new User("John", "Doe"),
    new User("Jane", "Doe"),
    new User("Cannolo", "Siciliano"),
    new User("Maria", "Rossi"),
};

// Instantiating UsersInMemory with the example users
var usersInMemory = toUsersInMemory(exampleUsers);

// Filtering by name
var filteredUsersByName = usersInMemory.filter(byName("Cannolo"));
WriteLine("Filtered by Name 'Cannolo':");
foreach (var user in filteredUsersByName)
{
    WriteLine($"Name: {user.Name}, LastName: {user.LastName}");
}

// Filtering by last name

var filteredUsersByLastName = usersInMemory.filter([
    byLastName("Doe"),
    byName("Jane")]
    );
WriteLine("\nFiltered by Composite filter :");
foreach (var user in filteredUsersByLastName)
{
    WriteLine($"Name: {user.Name}, LastName: {user.LastName}");
}

WriteLine("\n Filter by names");
foreach(var user in usersInMemory.filter(byNames(["jane","John","Pippo"])))
{
    WriteLine($"Name: {user.Name}, LastName: {user.LastName}");
}

WriteLine("\n Filter by predicate");
{
    foreach(var user in usersInMemory.filter(byPredicate(λ((User u) => 
                string.Equals(u.Name, "maria", StringComparison.OrdinalIgnoreCase)
                ))))
    {
        WriteLine($"Name: {user.Name}, LastName: {user.LastName}");
    }
}
usersInMemory.filter(byPredicate(λ<User, bool>(_ => true)));
#pragma warning restore CA1303