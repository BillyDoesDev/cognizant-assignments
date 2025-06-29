namespace NUnit_handson;

[TestFixture]
public class CalculatorTests {
    private IMathLibrary? _calculator;


    [SetUp]
    public void SetUp() {
        _calculator = new SimpleCalculator();
    }

    [TearDown]
    public void TearDown() {
        _calculator = null;
    }

    [TestCase(2, 3, 5)]
    [TestCase(-1, 4, 3)]
    [TestCase(0, 0, 0)]
    public void Addition_ReturnsExpected(double a, double b, double expected) {
        var result = _calculator!.Addition(a, b);
        Assert.That(result, Is.EqualTo(expected));
    }

}
