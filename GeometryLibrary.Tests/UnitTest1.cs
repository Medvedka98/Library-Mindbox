// ����-����� (���������� XUnit)
using GeometryLibrary;

public class GeometryTests
{   
    
    [Fact]
    public void CircleAreaCalculation()
    {
        // �������� �� ������������ ���������� ������� �����
        Circle circle = new Circle(5);
        Assert.Equal(Math.PI * 25, circle.CalculateArea(), 5); // �������� 5 ������ ����� �������
    }
    
    [Fact]
    public void TriangleAreaCalculation()
    {
        // �������� �� ������������ ���������� ������� ������������
        Triangle triangle = new Triangle(3, 4, 5);
        Assert.Equal(6, triangle.CalculateArea(), 5);
    }
    
    [Fact]
    public void InvalidTriangleSides()
    {
        // ��������, ��� ��� �������� ������������ � ������������� ��������� ���������� ����������.
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 5));
    }

    [Fact]
    public void RightAngledTriangleTest()
    {
        // ��������, ��� ����� IsRightAngled() ��������� ����������, �������� �� ����������� �������������.
        Triangle triangle = new Triangle(3, 4, 5);
        Assert.True(triangle.IsRightAngled());

        Triangle notRightTriangle = new Triangle(3, 4, 6);
        Assert.False(notRightTriangle.IsRightAngled());
    }

    [Fact]
    public void ZeroRadiusThrowsException()
    {
        // ��������, ��� ��� �������� ����� � ������� �������� ���������� ����������.
        Assert.Throws<ArgumentException>(() => new Circle(0));
    }

    [Fact]
    public void NegativeRadiusThrowsException()
    {
        // ��������, ��� ��� �������� ����� � ������������� �������� ���������� ����������.
        Assert.Throws<ArgumentException>(() => new Circle(-1));
    }

    [Fact]
    public void ZeroTriangleSideThrowsException()
    {
        // ��������, ��� ��� �������� ������������ � ������� �������� ���������� ����������.
        Assert.Throws<ArgumentException>(() => new Triangle(0, 4, 5));
    }

    [Fact]
    public void NegativeTriangleSideThrowsException()
    {
        // ��������, ��� ��� �������� ������������ � ������������� �������� ���������� ����������.
        Assert.Throws<ArgumentException>(() => new Triangle(-3, 4, 5));
    }
    [Fact]
    public void TriangleAreaCalculation_LargeNumbers()
    {
        //���� ��� �������� ������� ������ � �������� �������
        Triangle triangle = new Triangle(1000, 1000, 1000);
        double expectedArea = 433012.70189; //��������� ��������, ������������ �������
        Assert.Equal(expectedArea, triangle.CalculateArea(), 5);
    }

}