using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Vector : Tuple
    {

        public Vector() : base(0.0f, 0.0f, 0.0f, 0.0f)
        {

        }
        public Vector(float x = 0.0f, float y = 0.0f, float z = 0.0f, float w = 0.0f) : base(x, y, z, 0.0f)
        {

        }

        public Vector(Point p ): base(p.x, p.y, p.z, 0.0f)
        {

        }

        public static Point operator+(Vector a, Point b)
        {
            Point temp = new Point();
            temp.x = a.x + b.x;
            temp.y = a.y + b.y;
            temp.z = a.z + b.z;
            temp.w = a.w + b.w;

            return temp;
        }

        public static Point operator+(Point a, Vector b)
        {
            Point temp = new Point();
            temp.x = a.x + b.x;
            temp.y = a.y + b.y;
            temp.z = a.z + b.z;
            temp.w = a.w + b.w;

            return temp;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            Vector temp = new Vector();
            temp.x = a.x - b.x;
            temp.y = a.y - b.y;
            temp.z = a.z - b.z;
            temp.w = a.w - b.w;

            return temp;
        }

        public static Vector operator -(Vector a)
        {
            Vector temp = new Vector();
            temp.x = -a.x;
            temp.y = -a.y;
            temp.z = -a.z;
            temp.w = -a.w;

            return temp;
        }

        public static Vector operator *(Vector a, float b)
        {
            Vector temp = new Vector();
            temp.x = a.x * b;
            temp.y = a.y * b;
            temp.z = a.z * b;
            temp.w = a.w * b;

            return temp;
        }

        public static Vector operator *(float b, Vector a)
        {
            Vector temp = new Vector();
            temp.x = a.x * b;
            temp.y = a.y * b;
            temp.z = a.z * b;
            temp.w = a.w * b;

            return temp;
        }

        public static Vector operator* (Matrix4d a, Vector b)
        {
            Vector temp = new Vector();
            temp.x = a[0, 0] * b.x + a[0, 1] * b.y + a[0, 2] * b.z + a[0, 3] * b.w;
            temp.y = a[1, 0] * b.x + a[1, 1] * b.y + a[1, 2] * b.z + a[1, 3] * b.w;
            temp.z = a[2, 0] * b.x + a[2, 1] * b.y + a[2, 2] * b.z + a[2, 3] * b.w;
            temp.w = a[3, 0] * b.x + a[3, 1] * b.y + a[3, 2] * b.z + a[3, 3] * b.w;

            return temp;
        }

        public Vector Normalize()
        {
            float mag = (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);
            this.x = this.x / mag;
            this.y = this.y / mag;
            this.z = this.z / mag;
            this.w = this.w / mag;
            return this;
        }
        
        public static Vector Cross(Vector  a, Vector b)
        {
            Vector temp = new Vector();
            temp.x = a.y * b.z - a.z * b.y;
            temp.y = a.z * b.x - a.x * b.z;
            temp.z = a.x * b.y - a.y * b.x;

            return temp;
        }

        public static Vector Reflect(Vector incoming, Vector normal)
        {
            return incoming - normal * 2.0f * Dot(incoming, normal);
        }
        public float Dot(Vector a)
        {
            return this.x * a.x + this.y * a.y + this.z * a.z + this.w * a.w;
        }

        public static float Dot(Vector a, Vector b)
        {
            return b.x * a.x + b.y * a.y + b.z * a.z + b.w * a.w;
        }

    }
}
