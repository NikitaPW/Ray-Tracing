using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public class Point: Tuple
    {
        
        public Point() : base(0.0f, 0.0f, 0.0f, 1.0f)
        {

        }
        public Point(float x = 0.0f, float y = 0.0f, float z = 0.0f, float w = 1.0f) : base(x, y, z, w)
        {
            
        }
        public static Point operator +(Point a, Point b)
        {
            Point temp = new Point();
            temp.x = a.x + b.x;
            temp.y = a.y + b.y;
            temp.z = a.z + b.z;
            temp.w = a.w + b.w;

            return temp;
        }

        public static Point operator -(Point a, Point b)
        {
            Point temp = new Point();
            temp.x = a.x - b.x;
            temp.y = a.y - b.y;
            temp.z = a.z - b.z;
            temp.w = a.w - b.w;

            return temp;
        }

        public static Point operator -(Point a)
        {
            Point temp = new Point();
            temp.x = -a.x;
            temp.y = -a.y;
            temp.z = -a.z;
            temp.w = -a.w;

            return temp;
        }

        public Point Negate()
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
            this.w = -this.w;

            return this;
        }

        public static Point operator *(Point a, float b)
        {
            Point temp = new Point();
            temp.x = a.x * b;
            temp.y = a.y * b;
            temp.z = a.z * b;
            temp.w = a.w * b;

            return temp;

        }

        public static Point operator *(float b, Point a)
        {
            Point temp = new Point();
            temp.x = a.x * b;
            temp.y = a.y * b;
            temp.z= a.z * b;
            temp.w= a.w * b;

            return temp;
        }

        public static Point operator *(Matrix4d a, Point b)
        {
            Point temp = new Point();
            temp.x = a[0, 0] * b.x + a[0, 1] * b.y + a[0, 2] * b.z + a[0, 3] * b.w;
            temp.y = a[1, 0] * b.x + a[1, 1] * b.y + a[1, 2] * b.z + a[1, 3] * b.w;
            temp.z = a[2, 0] * b.x + a[2, 1] * b.y + a[2, 2] * b.z + a[2, 3] * b.w;
            temp.w = a[3, 0] * b.x + a[3, 1] * b.y + a[3, 2] * b.z + a[3, 3] * b.w;

            return temp;
        }

        public Point Scale(float s)
        {
            this.x *= s;
            this.y *= s;
            this.z *= s;
            this.w *= s;

            return this;
        }

        public Point Normalize()
        {
            float mag = this.Magnitude();
            this.x = this.x / mag;
            this.y = this.y / mag;
            this.z = this.z / mag;
            this.w = this.w / mag;
            return this;

        }
        public float Magnitude()
        {
            double temp = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);
            return (float)temp;
        }

        public float Dot(Point a)
        {
            return this.x * a.x + this.y * a.y + this.z * a.z + this.w * a.w;
        }

        public Point Normalized()
        {
            Point temp = new Point();
            float mag = this.Magnitude();
            temp.x = this.x / mag;
            temp.y = this.y / mag;
            temp.z = this.z / mag;
            temp.w = this.w / mag;

            return temp;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Point other = obj as Point;

            if (Help.FloatEquality(this.x, other.x) &&
                Help.FloatEquality(this.y, other.y) &&
                Help.FloatEquality(this.z, other.z) &&
                Help.FloatEquality(this.w, other.w))
                return true;
            return false;
        }
    }
}
