using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egor_Usachev_Task2
{
    public class Vector3
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public Vector3(float value)
        {
            X = Y = Z = value;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            return new Vector3(left.Y * right.Z - left.Z * right.Y,
                left.Z * right.X - left.X * right.Z,
                left.X * right.Y - left.Y * right.X);
        }

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Vector3 operator -(Vector3 value)
        {
            return new Vector3(-value.X, -value.Y, -value.Z);
        }

        public static Vector3 operator *(float left, Vector3 right)
        {
            return new Vector3(right.X * left, right.Y * left, right.Z * left);
        }

        public static Vector3 operator *(Vector3 left, float right)
        {
            return new Vector3(left.X * right, left.Y * right, left.Z * right);
        }

        public static Vector3 operator /(Vector3 left, float right)
        {
            return new Vector3(left.X / right, left.Y / right, left.Z / right);
        }

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            if (left.X == right.X && left.Y == right.Y && left.Z == right.Z)
                return true;
            else
                return false;
        }

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            if (left.X != right.X || left.Y != right.Y || left.Z != right.Z)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3 && (obj as Vector3) == this)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (X, Y, Z).GetHashCode();
        }

        public override string ToString()
        {
            return "X = " + X + " Y = " + Y + " Z = " + Z;
        }
    }
}
