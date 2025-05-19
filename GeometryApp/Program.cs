using System;
using GeometryLibrary;

namespace GeometryLibrary.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите радиус круга:");
                string radiusInput = Console.ReadLine();
                if (double.TryParse(radiusInput, out double radius))
                {
                    Circle circle = new Circle(radius);
                    double area = circle.CalculateArea();
                    Console.WriteLine($"Площадь круга с радиусом {radius}: {area}");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод радиуса.");
                }

                Console.WriteLine("\nВведите длины сторон треугольника (через пробел):");
                string triangleInput = Console.ReadLine();
                string[] sides = triangleInput.Split(' ');

                if (sides.Length == 3 &&
                    double.TryParse(sides[0], out double a) &&
                    double.TryParse(sides[1], out double b) &&
                    double.TryParse(sides[2], out double c))
                {
                    Triangle triangle = new Triangle(a, b, c);
                    double triangleArea = triangle.CalculateArea();
                    Console.WriteLine($"Площадь треугольника со сторонами {a}, {b}, {c}: {triangleArea}");
                    Console.WriteLine($"Треугольник прямоугольный: {triangle.IsRightAngled()}");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод сторон треугольника.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}