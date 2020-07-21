using System;
using System.Collections.Generic;
using System.Text;
using Task3.Figure;
using Task3.Materials;
using Task3.Shapes;

namespace Model.FigureBox
{
    /// <summary>
    /// Represents a single container for shapes.
    /// </summary>
    public class Box
    {
        /// <summary>
        /// Contains a collection of figures.
        /// </summary>
        Figure[] Figures { get; set; } = new Figure[20];
        /// <summary>
        /// Contains a class object.
        /// </summary>
        static Box box;
        /// <summary>
        /// Initializes a box object.
        /// </summary>
        /// <param name="figures"></param>
        private Box(Figure[] figures)
        {
            if (figures != null)
            {
                ClearBox();
                for (int i = 0; i < figures.Length && i < Figures.Length; i++)
                    Figures[i] = figures[i];
            }
        }
        /// <summary>
        /// Represents element-wise access to a collection.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Get a collection item by index. It also removes an item 
        /// from the collection.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Replaces a collection item by index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void ChangeElementAt(int index, Figure value)
        {
            if (index < GetCountOfFigures() && index >= 0)
                Figures[index] = value;
        }
        /// <summary>
        /// Finds a figure in a collection with similar 
        /// characteristics.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Figure FindSameFigure(Figure value)
        {
            foreach (Figure figure in Figures)
                if (figure.Equals(value))
                    return value;
            return null;
        }
        /// <summary>
        /// Returns an object of the class.
        /// </summary>
        /// <param name="figures"></param>
        /// <returns></returns>
        public static Box GetFiguresBox(Figure[] figures = null)
        {
            if (box == null)
                box = new Box(figures);
            return box;
        }
        /// <summary>
        /// Removes an existing item from the collection.
        /// </summary>
        /// <param name="figure"></param>
        private void DeleteElement(Figure figure)
        {
            Figure[] figures = new Figure[Figures.Length];
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
        /// <summary>
        /// Removes all elements from the collection.
        /// </summary>
        private void ClearBox()
        {
            for (int i = 0; i < Figures.Length; i++)
                Figures[i] = null;
        }
        /// <summary>
        /// Returns the total area of all figures in the collection.
        /// </summary>
        /// <returns></returns>
        public double GetAreaOfAllFigures()
        {
            double sum = 0;
            for (int i = 0, l = GetCountOfFigures(); i < l; i++)
                sum += Figures[i].GetArea();
            return sum;
        }
        /// <summary>
        /// Returns the total perimeter of all figures in the collection.
        /// </summary>
        /// <returns></returns>
        public double GetPerimeterOfAllFigures()
        {
            double sum = 0;
            for (int i = 0, l = GetCountOfFigures(); i < l; i++)
                sum += Figures[i].GetPerimeter();
            return sum;
        }
        /// <summary>
        /// Returns all circle figures from the collection.
        /// </summary>
        /// <returns></returns>
        public Figure[] GetAllCirclesFigures()
        {
            List<Figure> circles = new List<Figure>();
            for (int i = 0, l = GetCountOfFigures(); i < l; i++)
                if (Figures[i].GetShapeType() == typeof(Circle).GetType())
                    circles.Add(Figures[i]);
            return circles.ToArray();
        }
        /// <summary>
        /// Returns all film figures.
        /// </summary>
        /// <returns></returns>
        public Figure[] GetAllFilmFigures()
        {
            List<Figure> circles = new List<Figure>();
            for (int i = 0, l = GetCountOfFigures(); i < l; i++)
                if (Figures[i].GetShapeType() == typeof(Film).GetType())
                    circles.Add(Figures[i]);
            return circles.ToArray();
        }
        /// <summary>
        /// Adds a figure to the collection.
        /// </summary>
        /// <param name="figure"></param>
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
