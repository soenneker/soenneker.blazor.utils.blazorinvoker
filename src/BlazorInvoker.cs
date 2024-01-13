using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Soenneker.Blazor.Utils.BlazorInvoker.Abstract;

namespace Soenneker.Blazor.Utils.BlazorInvoker;

///<inheritdoc cref="IBlazorInvoker{TInput}"/>
public class BlazorInvoker<T> : IBlazorInvoker<T>
{
    private readonly Func<T, ValueTask> _func;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlazorInvoker{T}"/> class.
    /// </summary>
    /// <param name="invoker">The invoker function.</param>
    [DynamicDependency(nameof(Invoke))]
    public BlazorInvoker(Func<T, ValueTask> invoker)
    {
        _func = invoker;
    }

    [JSInvokable(nameof(Invoke))]
    public async ValueTask Invoke(T args)
    {
        await _func(args);
    }
}