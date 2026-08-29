using System.Threading.Tasks;

namespace Soenneker.Blazor.Utils.BlazorInvoker.Abstract;

/// <summary>
/// Wraps a value-task callback in an instance method that can be invoked through Blazor JavaScript interop.
/// </summary>
public interface IBlazorInvoker<in TInput>
{
    /// <summary>
    /// Invokes the configured callback and propagates its completion or failure to the caller.
    /// </summary>
    /// <param name="args">The value passed by the JavaScript caller.</param>
    /// <returns>A task that completes when the callback has finished running.</returns>
    ValueTask Invoke(TInput args);
}
