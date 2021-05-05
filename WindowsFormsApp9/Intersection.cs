using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Intersection
    {
        public Sphere sphere;
        public float t;

        public Intersection(Sphere obj, float t)
        {
            sphere = obj;
            this.t = t;
        }
    }
}
