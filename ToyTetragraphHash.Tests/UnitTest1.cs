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

    [Test]
    public void TestBlockString()
    {
        String input = "I leave twenty million dollars to my friendly cousin Bill.";
        ToyTetragraphHash hash = new ToyTetragraphHash();
        List<string[,]> blocks = hash.stringToBlocks(input);
        Assert.IsInstanceOf<string[,]>(blocks);

        Assert.Equals(3, blocks.Count);

    }


}
