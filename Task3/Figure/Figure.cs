using System;
using Task3.AbstractClasses;
using Task3.Colors;
using Task3.Interfaces;

namespace Task3.Figure
{
    /// <summary>
    /// Reflects the essence of the shape.
    /// </summary>
    public class Figure : ICloneable
    {
        /// <summary>
        /// Contains the shape of the figure.
        /// </summary>
        private BaseShape Shape { get; set; }
        /// <summary>
        /// Contains the material for the shape.
        /// </summary>
        private IMaterial Material { get; set; }
        /// <summary>
        /// Initializes a shape object.
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="material"></param>
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
        public Figure CutFigureFromThis(BaseShape shape)
        {
            return new Figure(Shape.TryCutShape(shape), Material);
        }
        public double GetArea()
        {
            return Shape.Area();
        }
        public double GetPerimeter()
        {
            return Shape.Perimeter();
        }
        /// <summary>
        /// Returns the type of the shape.
        /// </summary>
        /// <returns></returns>
        public Type GetShapeType()
        {
            return Shape.GetType();
        }
        /// <summary>
        /// Returns the type of the material.
        /// </summary>
        /// <returns></returns>
        public Type GetMaterialType()
        {
            return Material.GetType();
        }
        /// <summary>
        /// Paints the shape in the desired color. A figure cannot 
        /// be painted if it is already painted.
        /// </summary>
        /// <param name="color"></param>
        public void PaintFigure(MaterialColors color)
        {
            if (Material.CanBePainted)
                (Material as IPaintableMaterial).PaintMaterial(color);
            else
                throw new Exception("This material cannot be painted");
        }
        /// <summary>
        /// Returns true if the shape object has the same 
        /// shape and material.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Clones a shape object. Performs shallow copy.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Figure(Shape, Material);
        }
    }
}
