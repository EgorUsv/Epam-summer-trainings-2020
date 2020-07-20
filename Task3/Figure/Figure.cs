using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractClasses;
using Task3.Colors;
using Task3.Interfaces;

namespace Task3.Figure
{
    public class Figure
    {
        private BaseShape Shape { get; set; }
        private IMaterial Material { get; set; }

        public Figure(BaseShape shape, IMaterial material)
        {
            if (shape == null || material == null)
                throw new ArgumentNullException("Shape or material has null value");
            else
            {
                Shape = shape;
                Material = material;
            }
        }
        public double GetArea()
        {
            return Shape.Area();
        }
        public double GetPerimeter()
        {
            return Shape.Perimeter();
        }
        public Figure CutFigureFromThis(BaseShape shape)
        {
            return new Figure(Shape.TryCutShape(shape), Material);
        }
        public Type GetShapeType()
        {
            return Shape.GetType();
        }
        public Type GetMaterialType()
        {
            return Material.GetType();
        }
        public void PaintFigure(MaterialColors color)
        {
            if (Material.CanBePainted)
                (Material as IPaintableMaterial).PaintMaterial(color);
            else
                throw new Exception("This material cannot be painted");
        }
        public override bool Equals(object obj)
        {
            if (obj is Figure && Shape.Equals((obj as Figure).Shape) &&
                (obj as Figure).Material.Equals(Material))
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return (Shape.GetHashCode(), Material.GetHashCode()).GetHashCode();
        }

        public override string ToString()
        {
            return Shape.ToString() + "||" + Material.ToString();
        }

        public object Clone()
        {
            return new Figure(Shape, Material);
        }
    }
}
