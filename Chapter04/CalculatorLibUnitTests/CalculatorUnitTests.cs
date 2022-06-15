using Packt;
using Xunit;

namespace CalculatorLibUnitTests;

public class CalculatorLibUnitTests
{
    [Fact]
    public void TestAdding2And2()
    {
        //Arrange
        double a = 2;
        double b = 2;
        double expected = 4;

        Calculator calc = new();
    }
}