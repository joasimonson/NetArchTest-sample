using Mono.Cecil;
using NetArchTest.Rules;

namespace NetArchTestSample.Tests;

public class CustomRuleTests
{
    [Fact]
    public void ShouldMeetCustomRule()
    {
        var result = Types.InCurrentDomain()
            .That().AreClasses()
            .And().ResideInNamespace("NetArchTestSample.Services")
            .Should().MeetCustomRule(new CustomRule())
            .GetResult();

        Assert.True(result.IsSuccessful);
    }
}

public class CustomRule : ICustomRule
{
    public bool MeetsRule(TypeDefinition type) => type.Name.Contains("Service");
}