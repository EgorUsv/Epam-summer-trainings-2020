using System;
using System.Collections.Generic;
using System.Text;
using Task3.Figure;
using Task3.Materials;
using Task3.Shapes;

namespace Model.FigureBox
{
    public class Box
    {
        Figure[] Figures { get; set; } = new Figure[20];
        static Box box;
        private Box(Figure[] figures)
        {
            if (figures != null)
            {
                ClearBox();
                for (int i = 0; i < figures.Length && i < Figures.Length; i++)
                    Figures[i] = figures[i];
            }
        }
        public Figure this[int index]
        {
            get
            {
                if (index < GetCountOfFigures() && index >= 0)
                    return (Figure)Figures[index].Clone();
                else
                    throw new IndexOutOfRangeException();
            }
        }
        public Figure PopElementAt(int index)
        {
            if (index < GetCountOfFigures() && index >= 0)
            {
                Figure figure = (Figure)Figures[index].Clone();
                DeleteElement(figure);
                return figure;
            }
            else
                throw new IndexOutOfRangeException();
        }
        public void ChangeElementAt(int index, Figure value)
        {
            if (index < GetCountOfFigures() && index >= 0)
                Figures[index] = value;
        }
        public Figure FindSameFigure(Figure value)
        {
            foreach (Figure figure in Figures)
                if (figure.Equals(value))
                    return value;
            return null;
        }
        public static Box GetFiguresBox(Figure[] figures = null)
        {
            if (box == null)
                box = new Box(figures);
            return box;
        }
        private void DeleteElement(Figure figure)
        {
            Figure[] figures = new Figure[20];
            for (int i = 0, j = 0, l = GetCountOfFigures(); i < l; i++)
            {
                if (!Figures[i].Equals(figure))
                {
                    figures[j] = Figures[i];
                    j++;
                }
            }
            Figures = figures;
        }
        private void ClearBox()
        {
            for (int i = 0; i < Figures.Length; i++)
                Figures[i] = null;
        }
        public double GetAreaOfAllFigures()
        {
            double sum = 0;
            for (int i = 0, l = GetCountOfFigures(); i < l; i++)
                sum += Figures[i].GetArea();
            return sum;
        }
        public double GetPerimeterOfAllFigures()
        {
            double sum = 0;
            for (int i = 0, l = GetCountOfFigures(); i < l; i++)
                sum += Figures[i].GetPerimeter();
            return sum;
        }
        public Figure[] GetAllCirclesFigures()
        {
            List<Figure> circles = new List<Figure>();
            for (int i = 0, l = GetCountOfFigures(); i < l; i++)
                if (Figures[i].GetShapeType() == typeof(Circle).GetType())
                    circles.Add(Figures[i]);
            return circles.ToArray();
        }
        public Figure[] GetAllFilmFigures()
        {
            List<Figure> circles = new List<Figure>();
            for (int i = 0, l = GetCountOfFigures(); i < l; i++)
                if (Figures[i].GetShapeType() == typeof(Film).GetType())
                    circles.Add(Figures[i]);
            return circles.ToArray();
        }
        public void AddNewFigure(Figure figure)
        {
            if (figure != null && GetCountOfFigures() < 20 && !ContainsThisFigure(figure))
                Figures[GetCountOfFigures()] = figure;
        }
        public int GetCountOfFigures()
        {
            for (int i = 0; i < Figures.Length; i++)
            {
                if (Figures[i] == null)
                    return i;
            }
            return Figures.Length;
        }
        public bool ContainsThisFigure(Figure figure)
        {
            for (int i = 0, l = GetCountOfFigures(); i < l; i++)
                if (Figures[i].Equals(figure))
                    return true;
            return false;
        }
        public override string ToString()
        {
            string resultString = "";
            for (int i = 0, l = GetCountOfFigures(); i < l; i++)
            {
                if (i != l - 1)
                    resultString += Figures[i].ToString() + "\n";
                else
                    resultString += Figures[i].ToString();
            }
            return resultString;
        }
    }
}
