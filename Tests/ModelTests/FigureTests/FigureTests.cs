using System;
using System.Collections.Generic;
using System.Text;
using Task3.Figure;
using Task3.Materials;
using Task3.Shapes;
using Task3.Colors;
using Xunit;

namespace Tests.ModelTests.FigureTests
{
    public class FigureTests
    {
        [Fact]
        public void FigureTest()
        {
            ArgumentNullException actual = null;
            var expected = new ArgumentNullException("Shape or material has null value");
            try
            {
                var test = new Figure(null, null);
            }
            catch (ArgumentNullException e)
            {
                actual = e;
            }
            Assert.Equal(expected.Message, actual.Message);
        }
        [Fact]
        public void CutFigureFromThisTest()
        {
            var figure = new Figure(new Circle(10), new Film());
            var actual = figure.CutFigureFromThis(new Square(7));
            var expected = new Figure(new Square(7), new Film());
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetShapeTypeTest()
        {
            var figure = new Figure(new Circle(10), new Film());
            var actual = figure.GetShapeType();
            var expected = typeof(Circle);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetMaterialTypeTest()
        {
            var figure = new Figure(new Circle(10), new Film());
            var actual = figure.GetMaterialType();
            var expected = typeof(Film);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PaintFigureTest()
        {
            var figure = new Figure(new Circle(10), new Film());
            try
            {
                figure.PaintFigure(MaterialColors.Red);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }
        [Fact]
        public void PaintFigureTest1()
        {
            var figure = new Figure(new Circle(10), new Paper(MaterialColors.None));
            try
            {
                figure.PaintFigure(MaterialColors.Red);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
        [Fact]
        public void PaintFigureTest2()
        {
            var figure = new Figure(new Circle(10), new Paper(MaterialColors.Red));
            try
            {
                figure.PaintFigure(MaterialColors.Orange);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }
        [Fact]
        public void EqualsTest()
        {
            var figure = new Figure(new Circle(10), new Film());
            var figure2 = new Figure(new Circle(10), new Film());
            Assert.True(figure.Equals(figure2));
            Assert.True(figure != figure2);
        }
        [Fact]
        public void GetHashCodeTest()
        {
            var figure = new Figure(new Circle(10), new Film());
            var figure2 = new Figure(new Circle(10), new Film());
            Assert.True(figure.GetHashCode() == figure2.GetHashCode());
        }
        [Fact]
        public void ToStringTest()
        {
            var figure = new Figure(new Circle(10), new Film());
            Assert.True(figure.ToString() == new Circle(10).ToString() + "||" + new Film().ToString());
        }
        [Fact]
        public void CloneTest()
        {
            var figure = new Figure(new Circle(10), new Film());
            var figure2 = figure.Clone();
            Assert.True(figure != figure2);
            Assert.True(figure.Equals(figure2));
        }
    }
}
