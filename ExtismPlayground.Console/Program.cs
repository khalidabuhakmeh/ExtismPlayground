using Extism.Sdk;

var wasm = await File.ReadAllBytesAsync("ExtismPlayground.WasmPlugin.wasm");
var plugin = new Plugin(wasm,[], withWasi: true);

var result = plugin.Call("greet", "Khalid");

Console.WriteLine(result);