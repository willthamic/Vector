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

        public static Vector3 Normal(Vector3 u, Vector3 v)
        {
            float u1 = u.x;
            float u2 = u.y;
            float u3 = u.z;
            float v1 = v.x;
            float v2 = v.y;
            float v3 = v.z;

            float x = u2 * v3 - v2 * u3;
            float y = v1 * u3 - u1 * v3;
            float z = u1 * v2 - v1 * u2;
            return new Vector3(x, y, z).Unit();
        }

        public String ToString ()
        {
            return "<" + x + "," + y + "," + z + ">";
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

        public static Vector3 operator /(Vector3 a, float b)
        {
            return Scale(a, 1f / b);
        }

        public static Vector3 operator /(float a, Vector3 b)
        {
            return Scale(b, 1f / a);
        }
    }
}