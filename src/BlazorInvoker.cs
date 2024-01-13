using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Soenneker.Blazor.Utils.BlazorInvoker.Abstract;

namespace Soenneker.Blazor.Utils.BlazorInvoker;

///<inheritdoc cref="IBlazorInvoker{TInput}"/>
public class BlazorInvoker<TInput> : IBlazorInvoker<TInput>
{
    private readonly Func<TInput, ValueTask> _func;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlazorInvoker{TInput}"/> class.
    /// </summary>
    /// <param name="invoker">The invoker function.</param>
    [DynamicDependency(nameof(Invoke))]
    public BlazorInvoker(Func<TInput, ValueTask> invoker)
    {
        _func = invoker;
    }

    [JSInvokable(nameof(Invoke))]
    public async ValueTask Invoke(TInput args)
    {
        await _func(args);
    }
}