
using System;
using Xunit;

namespace GeometryLibrary
{
    // Абстрактный базовый класс для всех фигур
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    // Класс для круга
    public class Circle : Shape
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус должен быть больше нуля.");
            }
            _radius = radius;
        }

        public override double CalculateArea()
        {
            // Площадь круга: PI * R^2
            return Math.PI * _radius * _radius;
        }
    }

    // Класс для треугольника
    public class Triangle : Shape
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Длины сторон должны быть больше нуля.");
            }

            if (!IsValidTriangle(sideA, sideB, sideC))
            {
                throw new ArgumentException("Недопустимые длины сторон для треугольника.");
            }

            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }
        // Проверка, что стороны образуют допустимый треугольник, теорема неравенства треугольника
        private bool IsValidTriangle(double a, double b, double c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }

        public override double CalculateArea()
        {
            // Формула Герона для вычисления площади треугольника по трем сторонам
            double p = (_sideA + _sideB + _sideC) / 2;
            return Math.Sqrt(p * (p - _sideA) * (p - _sideB) * (p - _sideC));
        }

        public bool IsRightAngled()
        {
            // Проверка, является ли треугольник прямоугольным, используя теорему Пифагора
            double a2 = _sideA * _sideA;
            double b2 = _sideB * _sideB;
            double c2 = _sideC * _sideC;

            double delta = 1e-6; // Очень маленькое число для сравнения из-за погрешности double

            return Math.Abs(a2 + b2 - c2) < delta ||
                   Math.Abs(a2 + c2 - b2) < delta ||
                   Math.Abs(b2 + c2 - a2) < delta;
        }
    }
}
