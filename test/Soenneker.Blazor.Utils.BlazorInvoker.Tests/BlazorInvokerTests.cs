using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.Utils.BlazorInvoker.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class BlazorInvokerTests : HostedUnitTest
{
    public BlazorInvokerTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
