// Юнит-тесты (используем XUnit)
using GeometryLibrary;

public class GeometryTests
{   
    
    [Fact]
    public void CircleAreaCalculation()
    {
        // Проверка на корректность вычисления площади круга
        Circle circle = new Circle(5);
        Assert.Equal(Math.PI * 25, circle.CalculateArea(), 5); // Точность 5 знаков после запятой
    }
    
    [Fact]
    public void TriangleAreaCalculation()
    {
        // Проверка на корректность вычисления площади треугольника
        Triangle triangle = new Triangle(3, 4, 5);
        Assert.Equal(6, triangle.CalculateArea(), 5);
    }
    
    [Fact]
    public void InvalidTriangleSides()
    {
        // Проверка, что при создании треугольника с некорректными сторонами вызывается исключение.
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 5));
    }

    [Fact]
    public void RightAngledTriangleTest()
    {
        // Проверка, что метод IsRightAngled() правильно определяет, является ли треугольник прямоугольным.
        Triangle triangle = new Triangle(3, 4, 5);
        Assert.True(triangle.IsRightAngled());

        Triangle notRightTriangle = new Triangle(3, 4, 6);
        Assert.False(notRightTriangle.IsRightAngled());
    }

    [Fact]
    public void ZeroRadiusThrowsException()
    {
        // Проверка, что при создании круга с нулевым радиусом вызывается исключение.
        Assert.Throws<ArgumentException>(() => new Circle(0));
    }

    [Fact]
    public void NegativeRadiusThrowsException()
    {
        // Проверка, что при создании круга с отрицательным радиусом вызывается исключение.
        Assert.Throws<ArgumentException>(() => new Circle(-1));
    }

    [Fact]
    public void ZeroTriangleSideThrowsException()
    {
        // Проверка, что при создании треугольника с нулевой стороной вызывается исключение.
        Assert.Throws<ArgumentException>(() => new Triangle(0, 4, 5));
    }

    [Fact]
    public void NegativeTriangleSideThrowsException()
    {
        // Проверка, что при создании треугольника с отрицательной стороной вызывается исключение.
        Assert.Throws<ArgumentException>(() => new Triangle(-3, 4, 5));
    }
    [Fact]
    public void TriangleAreaCalculation_LargeNumbers()
    {
        //Тест для проверки формулы Герона с большими числами
        Triangle triangle = new Triangle(1000, 1000, 1000);
        double expectedArea = 433012.70189; //Ожидаемое значение, рассчитанное заранее
        Assert.Equal(expectedArea, triangle.CalculateArea(), 5);
    }

}