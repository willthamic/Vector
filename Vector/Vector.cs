using System;

namespace Vector
{
    /// <summary>
    /// Represents a 3-dimensional vector in Cartesian form.
    /// </summary>
    public class Vector3
    {
        public float x;
        public float y;
        public float z;
        
        public Vector3 (float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Returns the magnitude of a specified vector.
        /// </summary>
        public float Magnitude ()
        {
            return (float) Math.Sqrt(x * x + y * y + z * z);
        }

        public float MagSquared ()
        {
            return x * x + y * y + z * z;
        }

        /// <summary>
        /// Returns the unit vector corresponding to a specified vector..
        /// </summary>
        public Vector3 Unit ()
        {
            float magnitude = this.Magnitude();
            return new Vector3(x / magnitude, y / magnitude, z / magnitude);
        }

        /// <summary>
        /// Returns the normal unit vector to two specificed vectors.
        /// </summary>
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

        /// <summary>
        /// Converts the vector to its equivalent string representation.
        /// </summary>
        public String ToString ()
        {
            return "<" + x + "," + y + "," + z + ">";
        }

        /// <summary>
        /// Returns the sum of two specified vectors.
        /// </summary>
        public static Vector3 Sum (Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        /// <summary>
        /// Returns the difference between two specified vectors.
        /// </summary>
        public static Vector3 Subtract (Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        /// <summary>
        /// Returns the product of specified vector and scalar.
        /// </summary>
        public static Vector3 Scale (Vector3 a, float b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }

        /// <summary>
        /// Returns the dot product of two specified vectors.
        /// </summary>
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

    /// <summary>
    /// Represents a line in 3-dimensional space defined by an origin and direction vectors.
    /// </summary>
    public class Line
    {
        public Vector3 origin;
        public Vector3 direction;

        public Line(Vector3 o, Vector3 d)
        {
            origin = o;
            direction = d;
        }
    }

    /// <summary>
    /// Represents a 3-dimensional plane in Point-Normal form.
    /// </summary>
    public class Plane
    {
        public Vector3 normal;
        public float d;

        public Plane(Vector3 normal, float d)
        {
            this.normal = normal;
            this.d = d;
        }

        public Plane(float x, float y, float z, float d)
        {
            normal = new Vector3(x, y, z);
            this.d = d;
        }

        public Plane (Vector3 o, Vector3 u, Vector3 v)
        {
            normal = Vector3.Normal(u, v);
            d = Vector3.Dot(normal, o);
        }

        /// <summary>
        /// Converts the plane to its equivalent string representation.
        /// </summary>
        public String ToString ()
        {
            String x = normal.x >= 0 ? "+" + normal.x.ToString() : normal.x.ToString();
            String y = normal.y >= 0 ? "+" + normal.y.ToString() : normal.y.ToString();
            String z = normal.z >= 0 ? "+" + normal.z.ToString() : normal.z.ToString();
            return x + "x" + y + "y" + z + "z=" + d.ToString();
        }

        /// <summary>
        /// Returns the intersection of a specified line and plane.
        /// </summary>
        public static (bool, Vector3, float) RayCast(Line line, Plane plane)
        {
            line.direction = line.direction.Unit();
            float denominator = plane.normal.x * line.direction.x + plane.normal.y * line.direction.y + plane.normal.z * line.direction.z;
            if (denominator == 0)
                return (false, null, 0);
            float numerator = plane.d - plane.normal.x * line.origin.x - plane.normal.y * line.origin.y - plane.normal.z * line.origin.z;
            float t = (numerator / denominator) * 0.999999f;
            return (true, line.origin + line.direction * t, t);
        }
    }

}