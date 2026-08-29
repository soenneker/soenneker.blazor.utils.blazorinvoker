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
    /// <param name="args">Command-line arguments passed to the application.</param>
    /// <returns>A task that completes when the callback has finished running.</returns>
    ValueTask Invoke(TInput args);
}
