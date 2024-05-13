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