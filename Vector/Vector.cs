using System;

namespace Vector
{
    public class Vector3
    {
        float x = 0;
        float y = 0;
        float z = 0;

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
    }
}