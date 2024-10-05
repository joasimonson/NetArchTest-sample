using NetArchTest.Rules;
using NetArchTest.Rules.Policies;
using NetArchTestSample.Data.Interfaces;

namespace NetArchTestSample.Tests;

public class PolicyTests
{
    [Fact]
    public void ArchitecturePolicy_Should_Enforce_Rules()
    {
        var architecturePolicy = Policy.Define("Policy", "Base naming policy")
            .For(Types.InCurrentDomain)
            .Add(t =>
                t.That().ResideInNamespace("NetArchTestSample.Data.Interfaces")
                    .And().AreInterfaces()
                    .And().HaveName(typeof(IRepositoryBase<>).Name)
                    .Should().ImplementInterface(typeof(IAsyncDisposable)),
                "Base Repository Interface Rule",
                "Base class should implement IAsyncDisposable"
            )
            .Add(t =>
                t.That().ResideInNamespace("NetArchTestSample.Services")
                    .And().AreInterfaces()
                    .And().HaveNameEndingWith("Service")
                    .Should().ImplementInterface(typeof(IAsyncDisposable)),
                "Service Rule",
                "Service interfaces should implement IAsyncDisposable"
            );

        var result = architecturePolicy.Evaluate();

        Assert.False(result.HasViolations, "Some policies were violated.");
    }
}
