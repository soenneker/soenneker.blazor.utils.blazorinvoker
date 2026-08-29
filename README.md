[![](https://img.shields.io/nuget/v/soenneker.blazor.utils.blazorinvoker.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.blazorinvoker/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.blazorinvoker/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.blazorinvoker/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.utils.blazorinvoker.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.blazorinvoker/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.blazorinvoker/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.blazorinvoker/actions/workflows/codeql.yml)

# Soenneker.Blazor.Utils.BlazorInvoker

A generic invoker to simplify JavaScript to C# interaction.

## Install

```bash
dotnet add package Soenneker.Blazor.Utils.BlazorInvoker
```

## Quick start

```csharp
using Soenneker.Blazor.Utils.BlazorInvoker.Abstract;

IBlazorInvoker<TInput> blazorInvoker = /* resolve from DI */;
await blazorInvoker.Invoke(/* supply args */ default!);
```

Invokes the Blazor func set.

## What you get

- `IBlazorInvoker<TInput>` — A generic invoker to simplify JavaScript to C# interaction.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IBlazorInvoker<TInput>.Invoke(args)` | Invokes the Blazor func set. | A task that completes when the callback has finished running. |
