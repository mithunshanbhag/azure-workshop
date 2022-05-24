namespace AzureWorkshop.CodeSamples.XUnitTest;

public class Calc : ICalc
{
    public int Add(int x, int y)
    {
        return x + y;
    }

    public int Subtract(int x, int y)
    {
        return x - y;
    }

    public int Multiply(int x, int y)
    {
        return x * y;
    }

    public double Divide(int x, double y)
    {
        return x / y;
    }
}