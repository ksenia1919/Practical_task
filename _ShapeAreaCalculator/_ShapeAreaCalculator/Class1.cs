namespace _ShapeAreaCalculator
{
    /// <summary>
    /// Интерфейс для фигур.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Возвращает площадь фигуры
        /// </summary>
        /// <returns>Площадь фигуры</returns>
        double CalculateArea();
    }

    /// <summary>
    /// Класс для представления круга
    /// </summary>
    public class Circle : IShape
    {
        private readonly double _radius;

        /// <summary>
        /// Конструктор круга
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        public Circle(double radius)
        {
            _radius = radius;
        }

        /// <summary>
        /// Вычисляет площадь круга
        /// </summary>
        /// <returns>Площадь круга</returns>
        public double CalculateArea()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }
    }

    /// <summary>
    /// Класс для представления треугольника
    /// </summary>
    public class Triangle : IShape
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;

        /// <summary>
        /// Конструктор треугольника
        /// </summary>
        /// <param name="sideA">Длина первой стороны</param>
        /// <param name="sideB">Длина второй стороны</param>
        /// <param name="sideC">Длина третьей стороны</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }

        /// <summary>
        /// Вычисляет площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public double CalculateArea()
        {
            // Проверяем, является ли треугольник действительным
            if (!IsValidTriangle())
            {
                throw new ArgumentException("Треугольник не может быть создан с такими сторонами.");
            }

            // Вычисляем полупериметр
            double semi_p = (_sideA + _sideB + _sideC) / 2;

            // Используем формулу Герона
            return Math.Sqrt(semi_p * (semi_p - _sideA) * (semi_p - _sideB) * (semi_p - _sideC));
        }

        /// <summary>
        /// Проверяет, является ли треугольник действительным
        /// </summary>
        /// <returns>True, если треугольник действительный, иначе False </returns>
        private bool IsValidTriangle()
        {
            return _sideA + _sideB > _sideC &&
                   _sideA + _sideC > _sideB &&
                   _sideB + _sideC > _sideA;
        }

        /// <summary>
        /// Проверяет, является ли треугольник прямоугольным
        /// </summary>
        /// <returns>True, если треугольник прямоугольный, иначе False </returns>
        public bool IsRightTriangle()
        {
            // Сортируем стороны по возрастанию
            double[] sides = { _sideA, _sideB, _sideC };
            Array.Sort(sides);

            // Проверяем, выполняется ли теорема Пифагора
            return Math.Pow(sides[2], 2) == Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2);
        }
    }

    /// <summary>
    /// Класс для вычисления площади фигур
    /// </summary>
    public static class ShapeAreaCalculator
    {
        /// <summary>
        /// Вычисляет площадь фигуры
        /// </summary>
        /// <param name="shape">Фигура, для которой нужно вычислить площадь</param>
        /// <returns>Площадь фигуры</returns>
        public static double CalculateArea(IShape shape)
        {
            return shape.CalculateArea();
        }
    }
}