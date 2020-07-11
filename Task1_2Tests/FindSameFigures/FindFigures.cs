using System.Collections.Generic;
using System.Linq;
using Task2_1.Figures;
using Xunit;

namespace Task1_2Tests.FindSameFigures
{
    public class FindFigures
    {
        [Fact]
        public void FindIdenticalFigures()
        {
            var figures = new List<Figure>(6);
            figures.Add(new Triangle(new double[] { 3, 4, 5 }));
            figures.Add(new Square(6));
            figures.Add(new Rectangle(new double[] { 10, 6 }));
            figures.Add(new Square(8));
            figures.Add(new Triangle(new double[] { 14, 16, 17 }));
            figures.Add(new Rectangle(new double[] { 10, 6 }));
            var testFigure = new Rectangle(new double[] { 10, 6 });
            var expected = new List<Figure>
            {
                new Rectangle(new double[] { 10, 6 }),
                new Rectangle(new double[] { 10, 6 })
            };
            var actual = figures.FindAll(x => x.Equals(testFigure));
            Assert.True(Enumerable.SequenceEqual(expected, actual));
        }
    }
}
