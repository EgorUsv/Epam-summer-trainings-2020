using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Task3.AbstractClasses;
using Task3.Colors;
using Task3.Figure;
using Task3.Interfaces;

namespace Converter.Parser
{
    public static class FigureParser
    {
        public static Figure[] CreateFigures(string data)
        {
            List<Figure> figures = new List<Figure>();
            foreach (string figureString in data.Split('\n'))
            {
                string[] figureInfo = figureString.Split("||");
                BaseShape shape = GetShape(figureInfo[0]);
                IMaterial material = GetMaterial(figureInfo[1]);
                figures.Add(new Figure(shape, material));
            }
            return figures.ToArray();
        }
        private static BaseShape GetShape(string info)
        {
            List<double> sides = new List<double>();
            string typeName = Regex.Match(info, @"^\S*").Value;
            foreach (Match x in Regex.Matches(info.Substring(typeName.Length), @"(\d*[\,\.]\d*)|(\d+)"))
                sides.Add(double.Parse(x.Value));
            Type type = Type.GetType(typeName, false, true);
            if (sides.Count >= 2)
                return (BaseShape)Activator.CreateInstance(type, sides.ToArray());
            else
                return (BaseShape)Activator.CreateInstance(type, sides[0]);
        }
        private static IMaterial GetMaterial(string info)
        {
            string materialName = Regex.Match(info, @"^\S*").Value;
            var matches = Regex.Matches(info.Substring(materialName.Length), @"(\d+)");
            Type type = Type.GetType(materialName, false, true);
            if (matches.Count == 1)
                return (IMaterial)Activator.CreateInstance(type);
            else
                return (IMaterial)Activator.CreateInstance(type, (MaterialColors)int.Parse(matches[1].Value));
        }
    }
}
