using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Blazor.Utils.BlazorInvoker.Abstract;

/// <summary>
/// A generic invoker to simplify JavaScript to C# interaction
/// </summary>
public interface IBlazorInvoker<in TInput>
{
    /// <summary>
    /// Invokes the Blazor func set.
    /// </summary>
    /// <param name="args">The input argument.</param>
    /// <param name="cancellationToken"></param>
    ValueTask Invoke(TInput args, CancellationToken cancellationToken = default);
}
