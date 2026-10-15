using SampleApp.Samples;
namespace SampleApp.Tests.Samples;
[TestClass]
public class GreetingTests
{
    [TestMethod]
    public void Build_WithName_IncludesName() =>
        Assert.AreEqual("こんにちは、太郎 さん！", Greeting.Build("太郎"));

    [TestMethod]
    public void Build_WithEmptyName_ReturnsDefault() =>
        Assert.AreEqual("こんにちは！", Greeting.Build(""));
}