using DataSource1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task2_1.Figures;
using Xunit;
using FigureHandler;

namespace Task1_2Tests.FigureHandlerTests
{
    public class FigureHadlerTest
    {
        [Fact]
        public void FigureHandlerTest()
        {
            var expected = "sourceFile.txt";
            var actual = new DataSourceReader().Path;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void InitializeFigureTestTriangle()
        {
            double[] sides = new double[] { 3, 4, 5 };
            var expected = new Triangle(sides);
            var actual = FiguresHandler.InitializeFigure("triangle", sides);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void InitializeFigureTestRect()
        {
            double[] sides = new double[] { 3, 4 };
            var expected = new Rectangle(sides);
            var actual = FiguresHandler.InitializeFigure("rectangle", sides);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void InitializeFigureTestSquare()
        {
            double[] side = { 6 };
            var expected = new Square(side.First());
            var actual = FiguresHandler.InitializeFigure("square", side);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void InitializeFigureTestException()
        {
            double[] sides = { 6 };
            Figure expected = null;
            var actual = FiguresHandler.InitializeFigure("", sides);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetArrayOfFiguresTest()
        {
            string path = "..\\..\\..\\FigureHandlerTests\\sourceFile.txt";
            var actual = FiguresHandler.GetArray(new DataSourceReader(path));
            var figures = new List<Figure>(6);
            figures.Add(new Triangle(new double[] { 3, 4, 5 }));
            figures.Add(new Square(6));
            figures.Add(new Rectangle(new double[] { 10, 6 }));
            figures.Add(new Square(8));
            figures.Add(new Triangle(new double[] { 14, 16, 17 }));
            figures.Add(new Rectangle(new double[] { 20, 10 }));
            Assert.True(Enumerable.SequenceEqual(figures.ToArray(), actual));
        }
    }
}

