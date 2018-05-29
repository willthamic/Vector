using System;

namespace Vector
{
    public class Vector3
    {
        float x;
        float y;
        float z;

        public Vector3 (float x0, float y0, float z0)
        {
            x = x0;
            y = y0;
            z = z0;
        }

        public float Magnitude ()
        {
            return (float) Math.Sqrt(x * x + y * y + z * z);
        }

        public Vector3 Unit ()
        {
            float magnitude = this.Magnitude();
            return new Vector3(x / magnitude, y / magnitude, z / magnitude);
        }

        public static Vector3 Sum (Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 Subtract (Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 Scale (Vector3 a, float b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }

        public static float Dot (Vector3 a, Vector3 b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return Vector3.Sum(a, b);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return Vector3.Subtract(a, b);
        }

        public static Vector3 operator *(Vector3 a, float b)
        {
            return Scale(a, b);
        }

        public static Vector3 operator *(float a, Vector3 b)
        {
            return Scale(b, a);
        }
    }
}