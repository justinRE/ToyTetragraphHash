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

    [Test]
    public void TestCleanString()
    {
        ToyTetragraphHash hash = new ToyTetragraphHash();
        String result = hash.cleanString("My name is justin.!@#");
        Assert.AreEqual("mynameisjustin", result);

    }
    [Test]
    public void TestCreateTwoDimensionArrayFromString()
    {
        ToyTetragraphHash hash = new ToyTetragraphHash();
        String[,] result = hash.createTwoDimensionArrayFromString("ABCDEFGHIJKLMNOP");
        Assert.AreEqual(4,result.GetLength(0));
        Assert.AreEqual(4, result.GetLength(1));

    }

    [Test]
    public void TestInputSizeforTwoDimensionArrayFromStringTooLong()
    {
        ToyTetragraphHash hash = new ToyTetragraphHash();
        Assert.Throws<Exception>(
             delegate { hash.createTwoDimensionArrayFromString("ABCDEFGHIJKLMNOPQ"); });
    }

    [Test]
    public void TestInputSizeforTwoDimensionArrayFromStringTooShort()
    {
        ToyTetragraphHash hash = new ToyTetragraphHash();
        Assert.Throws<Exception>(
             delegate { hash.createTwoDimensionArrayFromString("ABCDEF"); });
    }

}
