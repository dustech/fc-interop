using System.Linq;

namespace FCInterop.Domain.C.Tests;

using System.Collections.Generic;
using static Users;
using Xunit;

public class UsersTests
{
    private IEnumerable<User> Users { get; set; } = new List<User>
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
        var cmd = create(new User("Bob"));
        var users = Users.ToList();
        var userRepo = toCommandUsers(users);

        userRepo.Invoke(cmd);

        Users = users;

        Assert.Equal(2, Users.Count());
    }

    [Fact]
    public void To_Users_In_Memory_Crate_Query_Interface()
    {
        var usersInMemory = toUsersInMemory(Users);

        Assert.IsAssignableFrom<Common.IQuery<Query, User>>(usersInMemory);
    }
    
    [Fact]
    public void Users_In_Memory_Query_Alice_By_Name_Return_Alice()
    {
        var usersInMemory = toUsersInMemory(Users);
        var query = byName("Alice");
        var expected = new User("Alice");

        var alice= usersInMemory.query(query).FirstOrDefault();
        
        Assert.Equal(expected,alice);
    }
    
    
}