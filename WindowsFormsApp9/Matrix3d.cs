using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Matrix3d
    {
        public float[,] mat;
        int size = 3;
        public Matrix3d(float m00 = 1.0f, float m01 = 0.0f, float m02 = 0.0f,
                 float m10 = 0.0f, float m11 = 1.0f, float m12 = 0.0f,
                 float m20 = 0.0f, float m21 = 0.0f, float m22 = 1.0f)
        {
            mat = new float[3, 3];
            mat[0, 0] = m00;
            mat[0, 1] = m01;
            mat[0, 2] = m02;

            mat[1, 0] = m10;
            mat[1, 1] = m11;
            mat[1, 2] = m12;

            mat[2, 0] = m20;
            mat[2, 1] = m21;
            mat[2, 2] = m22;
        }

        public float this[int r, int c]
        {
            get { return mat[r, c]; }
            set { mat[r, c] = value; }
        }

        public Matrix2d Sub(int x, int y)
        {
            Matrix2d sub = new Matrix2d();
            int i = 0;           

            for (int r = 0; r < this.size; r++)
            {
                int j = 0;
                if (r == x)
                    continue;
                for (int c = 0; c < this.size; c++)
                {
                    if (c == y)
                    {
                        continue;
                    }

                    sub[i, j] = this.mat[r, c];
                    j++;
                }
                i++;
            }
            return sub;
        }

        public float Minor(int x, int y)
        {
            Matrix2d sub = this.Sub(x, y);
            return sub.Det();
        }

        public float Cofactor(int r, int c)
        {
            float temp = this.Minor(r, c);
            if (((r+c)%2) != 0)
            {
                temp = temp  * -1.0f;
            }
            return temp;
        }

        public float Det()
        {
            return this[0, 0] * this.Cofactor(0, 0) +
                this[0, 1] * this.Cofactor(0, 1) +
                this[0, 2] * this.Cofactor(0, 2);
        }
    }
}
