using Xunit;

namespace AzureWorkshop.CodeSamples.XUnitTest;

public class XUnitTest
{
    private readonly ICalc _calc = new Calc();

    [Fact]
    public void PassingTest()
    {
        // arrange

        // act
        var retVal = _calc.Add(2, 2);

        // assert
        Assert.Equal(4, retVal);
    }

    [Fact]
    public void FailingTest()
    {
        // arrange

        // act
        var retVal = _calc.Add(2, 6);

        // assert
        Assert.Equal(4, retVal);
    }


    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(6)]
    public void PassingTheory(int value)
    {
        // arrange

        // act
        var retVal = _calc.Add(2, value);

        // assert
        Assert.Equal(2 + value, retVal);
    }

    [Theory]
    [InlineData(12)]
    [InlineData(15)]
    [InlineData(90)]
    public void FailingTheory(int value)
    {
        // arrange

        // act
        var retVal = _calc.Add(2, value);

        // assert
        Assert.Equal(2 * value, retVal);
    }
}