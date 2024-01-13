[![](https://img.shields.io/nuget/v/soenneker.blazor.utils.blazorinvoker.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.blazorinvoker/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.utils.blazorinvoker/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.utils.blazorinvoker/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.utils.blazorinvoker.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.utils.blazorinvoker/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Blazor.Utils.BlazorInvoker
### A generic invoker to simplify JavaScript to C# interaction

`BlazorInvoker<T>` is an encapsulation class designed as a generic invocation point from JS to C#. It's used for 'fire-and-forget' with no return value.


## Installation

```
dotnet add package Soenneker.Blazor.Utils.BlazorInvoker
```

## Usage

### C#
```csharp
var stringInvoker = new BlazorInvoker<string>(async (input) =>
{
    await SomeAsyncOperation(input);
});
```

### JS

```javascript
dotnetObject.invokeMethodAsync('Invoke', 'JavaScript argument');
```