namespace SampleApp.Samples;
public class Greeting
{
    public static string Build(string name) =>
        string.IsNullOrWhiteSpace(name) ? "こんにちは！" : $"こんにちは、{name} さん！";
}
