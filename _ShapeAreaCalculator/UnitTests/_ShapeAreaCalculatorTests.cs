using _ShapeAreaCalculator;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CalculateCircleArea_ValidRadius_ReturnsCorrectArea()
        {
            // Arrange
            double radius = 5;
            Circle circle = new Circle(radius);
            // Act
            double area = ShapeAreaCalculator.CalculateArea(circle);

            // Assert
            // ���������, ��� ����������� ������� ����� � �������� 5 ����� ���������� �������� (PI 5^2)
            Assert.AreEqual(Math.PI * Math.Pow(radius, 2), area);
        }

        [Test]
        public void CalculateTriangleArea_ValidSides_ReturnsCorrectArea()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            double area = ShapeAreaCalculator.CalculateArea(triangle);

            // Assert
            // ���������, ��� ����������� ������� ������������ �� ��������� 3, 4, 5 ����� 6
            Assert.AreEqual(6, area);
        }

        [Test]
        public void CalculateTriangleArea_InvalidSides_ThrowsArgumentException()
        {
            // Arrange
            double sideA = 1;
            double sideB = 2;
            double sideC = 5;

            // ������� ��������� ������������
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act & Assert
            // ���������, ��� ��� ������� ���������� ������� ������������� ���������� ArgumentException
            Assert.Throws<ArgumentException>(() => triangle.CalculateArea());
        }

        [Test]
        public void IsRightTriangle_ValidRightTriangle_ReturnsTrue()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            bool isRightTriangle = triangle.IsRightTriangle();

            // Assert
            // ���������, ��� ����� isRightTriangle() ���������� true ��� �������������� ������������ �� ��������� 3, 4, 5
            Assert.IsTrue(isRightTriangle);
        }

        [Test]
        public void IsRightTriangle_InvalidRightTriangle_ReturnsFalse()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 6;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            bool isRightTriangle = triangle.IsRightTriangle();

            // Assert
            // ���������, ��� ����� IsRightTriangle() ���������� false ��� ������������, ������� �� �������� �������������
            Assert.IsFalse(isRightTriangle);
        }
    }
}