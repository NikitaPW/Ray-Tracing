using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Computations
    {
        public float t;
        public Sphere sphere;
        public Point point;
        public Vector eye;
        public Vector normal;
        public bool inside;

        public static Computations PrepareComputations(Intersection i, Ray ray)
        {
            if (i == null)
            {
                return null;
            }

            Point temp = ray.Position(i.t);
            Computations c = new Computations();
            c.sphere = i.sphere;
            c.t = i.t;
            c.point = temp;
            c.eye = -ray.direction.Normalize(); ;
            c.normal = i.sphere.GetNormal(temp);

            if (c.normal.Dot(c.eye) < 0)
            {
                c.inside = true;
                c.normal = -c.normal;
            }
            else
            {
                c.inside = false;
            }
            return c;
        }

        public Computations()
        {

        }
    }
}
