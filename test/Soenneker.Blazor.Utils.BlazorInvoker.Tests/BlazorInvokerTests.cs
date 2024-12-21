using Soenneker.Blazor.Utils.BlazorInvoker.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Blazor.Utils.BlazorInvoker.Tests;

[Collection("Collection")]
public class BlazorInvokerTests : FixturedUnitTest
{
    public BlazorInvokerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
