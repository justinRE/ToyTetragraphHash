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
        List<string> blocks = hash.stringToBlocks(input);
        Assert.IsInstanceOf<List<string>>(blocks);

        Assert.AreEqual(3, blocks.Count);

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
        Assert.AreEqual(4, result.GetLength(0));
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

    [Test]
    public void TestCreateTwoDimensionArrayFromStringValueTest()
    {
        ToyTetragraphHash hash = new ToyTetragraphHash();
        String[,] result = hash.createTwoDimensionArrayFromString("ABCDEFGHIJKLMNOP");
        Assert.AreEqual(result[0, 0], "A");
        Assert.AreEqual(result[1, 0], "E");
        Assert.AreEqual(result[2, 2], "K");

    }

    [Test]
    public void TestCreateBlocks()
    {
        String input = "ileavetwentymilliondollarstomyfriendlycousinbill";
        ToyTetragraphHash hash = new ToyTetragraphHash();
        List<string> blocks = hash.createBlocks(input);
        Assert.IsInstanceOf<List<string>>(blocks);

        Assert.AreEqual(3, blocks.Count);

    }

    [Test]
    public void TestPadding()
    {
        String input = "ileavetwentymilliondollarstomyfriendlycousin";
        ToyTetragraphHash hash = new ToyTetragraphHash();
        List<string> blocks = hash.createBlocks(input);
        Assert.IsInstanceOf<List<string>>(blocks);

        Assert.AreEqual(3, blocks.Count);

    }

    [Test]
    public void TestRotateTwoDimensionArray()
    {
        ToyTetragraphHash hash = new ToyTetragraphHash();
        String[,] testArray = hash.createTwoDimensionArrayFromString("abcdefghijklmnop");
        String[,] rotatedArray = hash.rotateTwoDimensionArray(testArray);
        Assert.AreEqual("b", rotatedArray[0, 0]);
        Assert.AreEqual("h", rotatedArray[1, 1]);
        Assert.AreEqual("j", rotatedArray[2, 2]);
        Assert.AreEqual("m", rotatedArray[3, 3]);
    }

    [Test]
    public void convertToInts()
    {
        ToyTetragraphHash hash = new ToyTetragraphHash();
        String[,] testArray = hash.createTwoDimensionArrayFromString("abcdefghijklmnop");
        String[,] rotatedArray = hash.rotateTwoDimensionArray(testArray);
        Assert.AreEqual("b", rotatedArray[0, 0]);
        Assert.AreEqual("h", rotatedArray[1, 1]);
        Assert.AreEqual("j", rotatedArray[2, 2]);
        Assert.AreEqual("m", rotatedArray[3, 3]);
    }
}