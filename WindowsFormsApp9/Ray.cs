using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Ray
    {
        public Point origin;
        public Vector direction;

        public Ray()
        {
            this.origin = new Point();
            this.direction = new Vector();
        }
        public Ray(Point origin, Vector direction)
        {
            this.origin = origin;
            this.direction = direction;

        }

        public Point Position(float t)
        {
            return origin + this.direction * t;
        }

        public override string ToString()
        {
            return origin.ToString() + " -> " + direction.ToString();
        }

        public static Ray Transform(Ray ray, Matrix4d mat)
        {
            Ray temp;
            temp = mat * ray;
            return temp;
        }

        public static Ray operator*(Matrix4d mat, Ray ray)
        {
            Ray temp = new Ray();
            temp.origin = mat * ray.origin;
            temp.direction = mat * ray.direction;
            return temp;

        }
    }
}
