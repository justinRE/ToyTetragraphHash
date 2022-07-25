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
        Assert.AreEqual(hash.outTitle(), "Toy Tetragraph Hash: ");
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
        String[,] stringArray = new String[4, 4];
        stringArray[0, 0] = "i";
        stringArray[0, 1] = "l";
        stringArray[0, 2] = "e";
        stringArray[0, 3] = "a";
        stringArray[1, 0] = "v";
        stringArray[1, 1] = "e";
        stringArray[1, 2] = "t";
        stringArray[1, 3] = "w";
        stringArray[2, 0] = "e";
        stringArray[2, 1] = "n";
        stringArray[2, 2] = "t";
        stringArray[2, 3] = "y";
        stringArray[3, 0] = "m";
        stringArray[3, 1] = "i";
        stringArray[3, 2] = "l";
        stringArray[3, 3] = "l";
        int[,] numArray = hash.convertToInts(stringArray);
        Assert.AreEqual(8, numArray[0, 0]);
        Assert.AreEqual(4, numArray[1, 1]);
        Assert.AreEqual(19, numArray[2, 2]);
        Assert.AreEqual(11, numArray[3, 3]);

    }

    [Test]
    public void convertToIntsresult()
    {
        ToyTetragraphHash hash = new ToyTetragraphHash();
        String[,] stringArray = new String[4, 4];
        stringArray[0, 0] = "i";
        stringArray[0, 1] = "l";
        stringArray[0, 2] = "e";
        stringArray[0, 3] = "a";
        stringArray[1, 0] = "v";
        stringArray[1, 1] = "e";
        stringArray[1, 2] = "t";
        stringArray[1, 3] = "w";
        stringArray[2, 0] = "e";
        stringArray[2, 1] = "n";
        stringArray[2, 2] = "t";
        stringArray[2, 3] = "y";
        stringArray[3, 0] = "m";
        stringArray[3, 1] = "i";
        stringArray[3, 2] = "l";
        stringArray[3, 3] = "l";
        int[,] numArray = hash.convertToIntsresult(stringArray);
        Assert.AreEqual(8, numArray[0, 0]);
        Assert.AreEqual(4, numArray[1, 1]);
        Assert.AreEqual(19, numArray[2, 2]);
        Assert.AreEqual(11, numArray[3, 3]);

    }

    [Test]
    public void addColumns()
    {
        ToyTetragraphHash hash = new ToyTetragraphHash();
        int[,] intArray = new int[4, 4];
        intArray[0, 0] = 8;
        intArray[0, 1] = 21;
        intArray[0, 2] = 4;
        intArray[0, 3] = 12;
        intArray[1, 0] = 11;
        intArray[1, 1] = 4;
        intArray[1, 2] = 13;
        intArray[1, 3] = 8;
        intArray[2, 0] = 4;
        intArray[2, 1] = 19;
        intArray[2, 2] = 19;
        intArray[2, 3] = 11;
        intArray[3, 0] = 0;
        intArray[3, 1] = 22;
        intArray[3, 2] = 24;
        intArray[3, 3] = 11;
        int[] runningTotal = hash.addColumns(intArray);
        Assert.AreEqual(19, runningTotal[0]);
        Assert.AreEqual(10, runningTotal[1]);
        Assert.AreEqual(1, runningTotal[2]);
        Assert.AreEqual(5, runningTotal[3]);

    }

    [Test]
    public void runningTotalToString()
    {
        ToyTetragraphHash hash = new ToyTetragraphHash();
        int[] runningTotal = new int[4];
        runningTotal[0] = 1;
        runningTotal[1] = 5;
        runningTotal[2] = 16;
        runningTotal[3] = 6;
        string runningTotalTest = hash.runningTotalToString(runningTotal);
        Assert.AreEqual('B', runningTotal[0]);
        Assert.AreEqual('F', runningTotal[1]);
        Assert.AreEqual('Q', runningTotal[2]);
        Assert.AreEqual('G', runningTotal[3]);

    }

}