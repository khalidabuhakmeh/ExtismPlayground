# Extism Playground



This is a solution that combines the [Extism](https://extism.org) Plugin Development Kit (PDK) and the Extism Software Development Kit (SDK) into a producer/consumer example.

## Getting Started

1. You will need the `wasi-experimental` dotnet workload.
2. You'll also need the [WASI SDK](https://github.com/WebAssembly/wasi-sdk/releases) and set the `WASI_SDK_PATH` variable in your global `PATH`.

## Projects

The `ExtismPlayground.WasmPlugin` exports a .NET function of `greet` to be used by any Extism consumer regardless of technology stack or operating system using the power of Wasi.

Currently, Wasi works on the concept of arguments and outputs to the standard input and output. So you'll never see a method with parameters in C#.

```csharp
using System.Runtime.InteropServices;
using Extism;

public class Program
{
    [UnmanagedCallersOnly(EntryPoint = "greet")]
    public static int Greet()
    {
        var name = Pdk.GetInputString();
        var greeting = $"Hello, {name}!";
        Pdk.SetOutput(greeting);
        return 0;
    }
    
    public static void Main() {}
}
```

Additionally, you'll see all results being written to the host output. If you need complex results, those occur using **JSON**.

Consuming the `.wasm` file is as simple as including the `ExtismPlayground.WasmPlugin.wasm` file as content in a consuming project, then using the following code.

```csharp
using Extism.Sdk;

var wasm = await File.ReadAllBytesAsync("ExtismPlayground.WasmPlugin.wasm");
var plugin = new Plugin(wasm,[], withWasi: true);

var result = plugin.Call("greet", "Khalid");

Console.WriteLine(result);
```

Remember, all arguments and outputs are essentially command line arguments. The host can hold these "plugins" in memory for long-lived variables, but you're expected to write Host Functions to provide proxy access to files, web requests, or external resources.

Have fun!