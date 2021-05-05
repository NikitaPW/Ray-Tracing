using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    abstract public class Tuple
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Tuple(float x = 0.0f, float y = 0.0f, float z = 0.0f, float w = 0.0f)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public float Dot(Tuple a)
        {
            return this.x * a.x + this.y * a.y + this.z * a.z + this.w * a.w;
        }

        public static float Dot(Tuple a, Tuple b)
        {
            return b.x * a.x + b.y * a.y + b.z * a.z + b.w * a.w;
        }  
    }
}
