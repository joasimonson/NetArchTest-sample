using NetArchTest.Rules;
using NetArchTestSample.Data.Interfaces;

namespace NetArchTestSample.Tests;

public class ModifierTests
{
    [Fact]
    public void RepositoryShouldBeSealed()
    {
        var result = Types.InCurrentDomain()
            .That().ImplementInterface(typeof(IRepositoryBase<>))
            .And().AreClasses()
            .Should().BeSealed()
            .GetResult();

        Assert.True(result.IsSuccessful);
    }
}
