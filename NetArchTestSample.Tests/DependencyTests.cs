using NetArchTest.Rules;

namespace NetArchTestSample.Tests;

public class DependencyTests
{
    [Fact]
    public void PresentationShouldNotReferenceData()
    {
        var result = Types.InCurrentDomain()
            .That().ResideInNamespace("NetArchTestSample.Presentation")
            .ShouldNot().HaveDependencyOn("NetArchTestSample.Data")
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void OnlyDataShouldReferenceSystemData()
    {
        var result = Types.InCurrentDomain()
            .That().HaveDependencyOn("System.Data")
            .And().ResideInNamespace("NetArchTestSample")
            .Should().ResideInNamespace("NetArchTestSample.Data")
            .GetResult();

        Assert.True(result.IsSuccessful);
    }
}
