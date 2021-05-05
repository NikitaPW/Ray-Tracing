using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Matrix2d
    {
        public float[,] mat;

        public Matrix2d(float m00 = 1.0f, float m01 = 0.0f, float m10 = 0.0f, float m11 = 1.0f)
        {
            mat = new float[2, 2];
            mat[0, 0] = m00;
            mat[0, 1] = m01;
            mat[1, 0] = m10;
            mat[1, 1] = m11;
        }

        public float this[int r, int c]
        {
            get { return mat[r, c]; }
            set { mat[r, c] = value; }
        }

        public float Det()
        {
            return mat[0,0] *mat[1, 1] - mat[0, 1] * mat[1, 0];
        }
    }
}
