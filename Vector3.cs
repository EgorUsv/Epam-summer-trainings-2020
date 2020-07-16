using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egor_Usachev_Task2
{
    /// <summary>
    /// Represents a vector with three single-precision floating-point values.
    /// </summary>
    public class Vector3
    {
        /// <summary>
        /// The X component of the vector.
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// The Y component of the vector.
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        /// The Z component of the vector.
        /// </summary>
        public float Z { get; set; }
        /// <summary>
        /// Creates a new Vector3 object whose three elements have the same
        /// value.
        /// </summary>
        /// <param name="value"></param>
        public Vector3(float value)
        {
            X = Y = Z = value;
        }
        /// <summary>
        /// Creates a vector whose elements have the specified values.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        /// <summary>
        /// Adds two vectors together.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }
        /// <summary>
        /// Multiplies two vectors together.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            return new Vector3(left.Y * right.Z - left.Z * right.Y,
                left.Z * right.X - left.X * right.Z,
                left.X * right.Y - left.Y * right.X);
        }
        /// <summary>
        /// Subtracts the first vector from the second.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }
        /// <summary>
        /// Negates the specified vector.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 value)
        {
            return new Vector3(-value.X, -value.Y, -value.Z);
        }
        /// <summary>
        /// Multiples the scalar value by the specified vector.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator *(float left, Vector3 right)
        {
            return new Vector3(right.X * left, right.Y * left, right.Z * left);
        }
        /// <summary>
        ///  Multiples the specified vector by the specified scalar value.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 left, float right)
        {
            return new Vector3(left.X * right, left.Y * right, left.Z * right);
        }
        /// <summary>
        /// Divides the specified vector by a specified scalar value.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator /(Vector3 left, float right)
        {
            return new Vector3(left.X / right, left.Y / right, left.Z / right);
        }
        /// <summary>
        /// Returns a value that indicates whether each pair of elements in two specified
        /// vectors is equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Vector3 left, Vector3 right)
        {
            if (left.X == right.X && left.Y == right.Y && left.Z == right.Z)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns a value that indicates whether two specified vectors are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Vector3 left, Vector3 right)
        {
            if (left.X != right.X || left.Y != right.Y || left.Z != right.Z)
                return true;
            else
                return false;
        }
        /// <summary>
        ///  Returns a value that indicates whether this instance and a specified object are
        ///  equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector3 && (obj as Vector3) == this)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns the hash code for the tuple that contains X, Y and Z component.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (X, Y, Z).GetHashCode();
        }
        /// <summary>
        /// Returns a string with the values of the vector components.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "X = " + X + " Y = " + Y + " Z = " + Z;
        }
    }
}
