using DataSource1_2;
using System;
using System.Linq;
using Task2_1.Figures;

namespace FigureHandler
{
    public class FiguresHandler
    {
        public static Figure InitializeFigure(string name, double[] sides)
        {
            if (sides == null || sides.Length == 0)
                return default;
            switch (name)
            {
                case "triangle":
                    return new Triangle(sides);
                case "square":
                    return new Square(sides.First());
                case "rectangle":
                    return new Rectangle(sides);
                default:
                    return default;
            }
        }
        public static Figure[] GetArray(DataSourceReader dsr)
        {
            if (dsr.ReadData(out string data))
            {
                var figureInfo = data.Split('\n');
                Figure[] figures = InitializeArray(figureInfo);
                return figures;
            }
            else
                return default;

        }
        private static Figure[] InitializeArray(string[] figuresInfo)
        {
            Figure[] figuresArray = new Figure[figuresInfo.Length];
            try
            {
                int arrIndex = 0;
                foreach (string info in figuresInfo)
                {
                    string[] figure = info.Split(' ');
                    double[] sides = figure.Skip(1)
                        .Select(s => double.Parse(s)).ToArray();
                    figuresArray[arrIndex] = InitializeFigure(figure[0], sides);
                    arrIndex++;
                }
                return figuresArray;
            }
            catch (Exception)
            {
                return figuresArray;
            }
        }
    }
}
