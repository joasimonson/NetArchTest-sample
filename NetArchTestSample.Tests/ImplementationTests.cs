using NetArchTest.Rules;
using NetArchTestSample.Data.Interfaces;

namespace NetArchTestSample.Tests;

public class ImplementationTests
{
    [Fact]
    public void ShouldNotHaveClassesOnInterfaceNamespace()
    {
        var result = Types.InCurrentDomain()
            .That().ResideInNamespace("NetArchTestSample.Data.Interfaces")
            .ShouldNot().BeClasses()
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void RepositoryShouldImplementBase()
    {
        var result = Types.InCurrentDomain()
            .That().ResideInNamespace("NetArchTestSample.Data")
            .And().AreClasses()
            .And().HaveNameEndingWith("Repository")
            .Should().ImplementInterface(typeof(IRepositoryBase<>))
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void RepositoryClassesShouldBeSuffixed()
    {
        var result = Types.InCurrentDomain()
            .That().ImplementInterface(typeof(IRepositoryBase<>))
            .And().ResideInNamespace("NetArchTestSample.Data")
            .Should().HaveNameEndingWith("Repository")
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void InterfacesShouldBePrefixed()
    {
        var result = Types.InCurrentDomain()
            .That().AreInterfaces()
            .Should().HaveNameStartingWith("I")
            .GetResult();

        Assert.True(result.IsSuccessful);
    }
}
