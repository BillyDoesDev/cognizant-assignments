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

    [TestCase(5, 3, 2)]
    [TestCase(10, 4, 6)]
    public void Subtraction_ReturnsExpected(double a, double b, double expected) {
        var result = _calculator!.Subtraction(a, b);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(2, 3, 6)]
    [TestCase(-2, 4, -8)]
    public void Multiplication_ReturnsExpected(double a, double b, double expected) {
        var result = _calculator!.Multiplication(a, b);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(10, 2, 5)]
    [TestCase(9, 3, 3)]
    public void Division_ReturnsExpected(double a, double b, double expected) {
        var result = _calculator!.Division(a, b);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Division_ByZero_ThrowsException() {
        Assert.Throws<System.ArgumentException>(() => _calculator!.Division(5, 0));
    }

}
