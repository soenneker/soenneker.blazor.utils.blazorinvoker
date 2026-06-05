using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Soenneker.Blazor.Utils.BlazorInvoker.Abstract;
using Soenneker.Extensions.ValueTask;

namespace Soenneker.Blazor.Utils.BlazorInvoker;

///<inheritdoc cref="IBlazorInvoker{TInput}"/>
public sealed class BlazorInvoker<TInput> : IBlazorInvoker<TInput>
{
    private readonly Func<TInput, ValueTask> _func;

    [DynamicDependency(nameof(Invoke))]
    public BlazorInvoker(Func<TInput, ValueTask> invoker)
    {
        _func = invoker;
    }

    // CancellationToken cannot be a parameter because this is called from JS
    [JSInvokable(nameof(Invoke))]
    public async ValueTask Invoke(TInput args)
    {
        await _func(args);
    }
}
