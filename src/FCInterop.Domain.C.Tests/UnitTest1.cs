namespace FCInterop.Domain.C.Tests;
using System.Collections.Generic;
using static UsersFu;
using Xunit;


public class UsersPrimeTests
{
    public IEnumerable<UserFu> Users =>
        new List<UserFu>
        {
            new("Alice")
        };
    
    [Fact]
    public void Filter_by_single_name_works()
    {
        var query = byName("Alice");
        var userRepo = toQueryableUsers(Users);

        var result = userRepo.Invoke(query);
        
        Assert.Equal(Users,result);
    }
}