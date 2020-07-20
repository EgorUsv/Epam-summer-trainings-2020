using Converter.Parser;
using DataSource.StreamClasses;
using Model.FigureBox;
using System.Collections.Generic;
using System.Linq;
using Task3.AbstractClasses;
using Task3.Figure;
using Task3.Materials;
using Task3.Shapes;
using Xunit;

namespace Tests.ParserTests
{
    public class ParserTests
    {
        public List<Figure> Figures { get; set; } = new List<Figure>();
        public string Path { get; set; } = "testFile.xml";
        public ParserTests()
        {
            Figure figure1 = new Figure(new Circle(6.3), new Film());
            BaseShape shape2 = new Rectangle(new double[] { 5, 8.3 });
            Figure figure2 = new Figure(shape2, new Paper(Task3.Colors.MaterialColors.Orange));
            Box testArray = Box.GetFiguresBox();
            testArray.AddNewFigure(figure1);
            testArray.AddNewFigure(figure2);
            Figures.Add(figure1);
            Figures.Add(figure2);
            MyStreamWriter.SaveData(testArray.ToString(), Path);
        }
        [Fact]
        public void ConverterTest()
        {
            string info = MyStreamReader.ReadData(Path);
            Figure[] figures = FigureParser.CreateFigures(info);
            Assert.True(Enumerable.SequenceEqual(Figures, figures));
        }
    }
}
