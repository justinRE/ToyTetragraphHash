namespace ToyTetragraphHash.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestTitle()
    {
        ToyTetragraphHash hash = new ToyTetragraphHash();
        Assert.AreEqual(hash.outTitle(), "ToyTetragraphHash");
        Assert.Pass();
    }
}
