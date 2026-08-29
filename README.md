[![](https://img.shields.io/nuget/v/soenneker.blazor.utils.blazorinvoker.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.blazorinvoker/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.blazorinvoker/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.blazorinvoker/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.utils.blazorinvoker.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.blazorinvoker/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.blazorinvoker/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.blazorinvoker/actions/workflows/codeql.yml)

# Soenneker.Blazor.Utils.BlazorInvoker

A small adapter that exposes a `Func<TInput, ValueTask>` as an instance `[JSInvokable]` method for JavaScript-to-.NET callbacks.

## Installation

```bash
dotnet add package Soenneker.Blazor.Utils.BlazorInvoker
```

There is no service registration. Create an invoker for a specific callback, wrap it in a `DotNetObjectReference`, and pass that reference to your JavaScript module.

## Component example

```razor
@using Microsoft.JSInterop
@using Soenneker.Blazor.Utils.BlazorInvoker
@implements IAsyncDisposable
@inject IJSRuntime JS

<p>@_message</p>

@code {
    private IJSObjectReference? _module;
    private BlazorInvoker<BrowserMessage>? _invoker;
    private DotNetObjectReference<BlazorInvoker<BrowserMessage>>? _reference;
    private string? _message;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
            return;

        _invoker = new BlazorInvoker<BrowserMessage>(message =>
            new ValueTask(InvokeAsync(() =>
            {
                _message = message.Text;
                StateHasChanged();
            })));

        _reference = DotNetObjectReference.Create(_invoker);
        _module = await JS.InvokeAsync<IJSObjectReference>("import", "./callback.js");
        await _module.InvokeVoidAsync("registerCallback", _reference);
    }

    public async ValueTask DisposeAsync()
    {
        if (_module is not null)
        {
            await _module.InvokeVoidAsync("unregisterCallback");
            await _module.DisposeAsync();
        }

        _reference?.Dispose();
    }

    private sealed record BrowserMessage(string Text);
}
```

The JavaScript side receives the object reference and invokes its `Invoke` method:

```javascript
let callback;

export function registerCallback(reference) {
    callback = reference;
}

export function unregisterCallback() {
    callback = null;
}

export async function publish(text) {
    if (!callback)
        throw new Error("The .NET callback has not been registered.");

    await callback.invokeMethodAsync("Invoke", { text });
}
```

## Behavior and ownership

- `Invoke(args)` awaits the configured delegate. A delegate exception rejects JavaScript's `invokeMethodAsync` promise, so JavaScript callers should await and handle failures.
- The invoker does not marshal work onto a component renderer. Use the owning component's `InvokeAsync` when the delegate changes component state or calls `StateHasChanged`.
- JavaScript cannot supply a .NET `CancellationToken` to this method. Capture a component or operation token in the delegate when cancellation is required.
- The invoker does not create or dispose `DotNetObjectReference`. The owner must retain and dispose that reference, or the delegate and any captured component state remain rooted.
- A disposed object reference must not be invoked again. Unregister browser listeners before disposal when they can race with component teardown.
- Treat callback payloads as untrusted input. Validate values, sizes, identifiers, and authorization before using them in privileged operations.

`BlazorInvoker<TInput>` is useful when several interop wrappers need the same one-argument callback shape. For a component with multiple named callbacks, ordinary `[JSInvokable]` instance methods may be clearer.
