// using System;
// using System.Collections.Generic;
// using static FCInterop.Domain.Common;
// using static FCInterop.Domain.UsersSeq;
// using static System.Console;
// using static FCInterop.Domain.Entities;
//
// #pragma warning disable CA1303
//
// var exampleUsers = new List<User>()
// {
//     new ("John", "Doe"),
//     new ("Jane", "Doe"),
//     new ("Cannolo", "Siciliano"),
//     new ("Maria", "Rossi"),
// };
//
// // Instantiating UsersInMemory with the example users
// var usersInMemory = toUsersInMemory(exampleUsers);
//
// // Filtering by name
// var filteredUsersByName = usersInMemory.filter(byName("Cannolo"));
// WriteLine("Filtered by Name 'Cannolo':");
// foreach (var user in filteredUsersByName)
// {
//     WriteLine($"Name: {user.Name}, LastName: {user.LastName}");
// }
//
// // Filtering by last name
//
// var filteredUsersByLastName = usersInMemory.filter([
//     byLastName("Doe"),
//     byName("Jane")]
//     );
// WriteLine("\nFiltered by Composite filter :");
// foreach (var user in filteredUsersByLastName)
// {
//     WriteLine($"Name: {user.Name}, LastName: {user.LastName}");
// }
//
// WriteLine("\n Filter by names");
// foreach(var user in usersInMemory.filter(byNames(["jane","John","Pippo"])))
// {
//     WriteLine($"Name: {user.Name}, LastName: {user.LastName}");
// }
//
// WriteLine("\n Filter by predicate");
// {
//     foreach(var user in usersInMemory.filter(byPredicate(λ((User u) => 
//                 string.Equals(u.Name, "maria", StringComparison.OrdinalIgnoreCase)
//                 ))))
//     {
//         WriteLine($"Name: {user.Name}, LastName: {user.LastName}");
//     }
// }
// usersInMemory.filter(byPredicate(λ<User, bool>(_ => true)));
// #pragma warning restore CA1303


using System.Collections.Generic;
using FCInterop.Domain;
using static FCInterop.Domain.Users;
using static System.Console;

#pragma warning disable CA1303
WriteLine("Starting computation.");

var exampleUsers = new List<Entities.User>()
{
    new("John", "Doe"),
    new("Jane", "Doe"),
    new("Cannolo", "Siciliano"),
    new("Maria", "Rossi"),
};

var userRepository = InMemory.toUsersInMemory(exampleUsers);

var result = userRepository.query(byName("John"));

foreach (var user in result)
{
    {
        WriteLine($"Name: {user.Name}, LastName: {user.LastName}");
    }
}

WriteLine("Ending computation.");
#pragma warning restore CA1303