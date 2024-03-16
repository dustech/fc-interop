using System.Linq;

namespace FCInterop.Domain.C.Tests;

using System.Collections.Generic;
using static UsersFu;
using Xunit;

public class UsersPrimeTests
{
    private IEnumerable<UserFu> Users { get; set; } = new List<UserFu>
    {
        new("Alice")
    };

    [Fact]
    public void Filter_by_single_name_works()
    {
        var query = byName("Alice");
        var userRepo = toQueryableUsers(Users);

        var result = userRepo.Invoke(query);

        Assert.Equal(Users, result);
    }

    [Fact]
    public void Insert_single_user_have_count_two()
    {
        var cmd = insert(new UserFu("Bob"));
        var users = Users.ToList();
        var userRepo = toCommandUsers(users);

        userRepo.Invoke(cmd);

        Users = users;

        Assert.Equal(2, Users.Count());
    }
}