using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Matrix4d
    {
        public float[,] mat;
        int size = 4;

        public float this[int r, int c]
        {
            get { return mat[r, c]; }
            set { mat[r, c] = value; }
        }
        public Matrix4d(float m00 = 1.0f, float m01 = 0.0f, float m02 = 0.0f, float m03 = 0.0f,
                 float m10 = 0.0f, float m11 = 1.0f, float m12 = 0.0f, float m13 = 0.0f,
                 float m20 = 0.0f, float m21 = 0.0f, float m22 = 1.0f, float m23 = 0.0f,
                 float m30 = 0.0f, float m31 = 0.0f, float m32 = 0.0f, float m33 = 1.0f)
        {
            mat = new float[4, 4];
            mat[0, 0] = m00;
            mat[0, 1] = m01;
            mat[0, 2] = m02;
            mat[0, 3] = m03;

            mat[1, 0] = m10;
            mat[1, 1] = m11;
            mat[1, 2] = m12;
            mat[1, 3] = m13;

            mat[2, 0] = m20;
            mat[2, 1] = m21;
            mat[2, 2] = m22;
            mat[2, 3] = m23;

            mat[3, 0] = m30;
            mat[3, 1] = m31;
            mat[3, 2] = m32;
            mat[3, 3] = m33;
        }

        public Matrix4d(Matrix4d a)
        {
            mat = new float[4, 4];
            mat[0, 0] = a[0, 0];
            mat[0, 1] = a[0, 1];
            mat[0, 2] = a[0, 2];
            mat[0, 3] = a[0, 3];

            mat[1, 0] = a[1, 0];
            mat[1, 1] = a[1, 1];
            mat[1, 2] = a[1, 2];
            mat[1, 3] = a[1, 3];

            mat[2, 0] = a[2, 0];
            mat[2, 1] = a[2, 1];
            mat[2, 2] = a[2, 2];
            mat[2, 3] = a[2, 3];

            mat[3, 0] = a[3, 0];
            mat[3, 1] = a[3, 1];
            mat[3, 2] = a[3, 2];
            mat[3, 3] = a[3, 3];
        }

        public static Matrix4d TranslateMatrix(float x, float y, float z)
        {
            Matrix4d temp = new Matrix4d();

            temp[0, 3] = x;
            temp[1, 3] = y;
            temp[2, 3] = z;

            return temp;
        }

        public static Matrix4d ScaleMatrix(float x, float y, float z)
        {
            Matrix4d temp = new Matrix4d();

            temp[0, 0] = x;
            temp[1, 1] = y;
            temp[2, 2] = z;

            return temp;
        }

        public static Matrix4d RotateMatrix(float x, float y, float z)
        {
            Matrix4d tempX = Matrix4d.RotateXMatrix(x);
            Matrix4d tempY = Matrix4d.RotateYMatrix(y);
            Matrix4d tempZ = Matrix4d.RotateZMatrix(z);
            return tempX * tempY * tempZ;
        }

        public static Matrix4d RotateXMatrix(float x)
        {
            Matrix4d temp = new Matrix4d();

            temp[1, 1] = (float)Math.Cos(x);
            temp[1, 2] = (float)Math.Sin(x) * -1.0f;
            temp[2, 1] = (float)Math.Sin(x);
            temp[2, 2] = (float)Math.Cos(x);

            return temp;
        }

        public static Matrix4d RotateYMatrix(float y)
        {
            Matrix4d temp = new Matrix4d();

            temp[0, 0] = (float)Math.Cos(y);
            temp[0, 2] = (float)Math.Sin(y) ;
            temp[2, 0] = (float)Math.Sin(y) * -1.0f;
            temp[2, 2] = (float)Math.Cos(y);
            return temp;
        }


        public static Matrix4d RotateZMatrix(float z)
        {
            Matrix4d temp = new Matrix4d();

            temp[0, 0] = (float)Math.Cos(z);
            temp[0, 1] = (float)Math.Sin(z) * -1.0f;
            temp[1, 0] = (float)Math.Sin(z) ;
            temp[1, 1] = (float)Math.Cos(z);
            return temp;
        }

        public static Matrix4d operator *(Matrix4d a, Matrix4d b)
        {
            Matrix4d temp = new Matrix4d();
            for (int r = 0; r < a.size; r++)
            {
                for (int c = 0; c < a.size; c++)
                {
                    temp[r, c] = a[r, 0] * b[0, c] +
                                 a[r, 1] * b[1, c] + 
                                 a[r, 2] * b[2, c] + 
                                 a[r, 3] * b[3, c];
                }
            }
            return temp;
        }

        public static Matrix4d operator *(Matrix4d a, float b)
        {
            Matrix4d temp = new Matrix4d(a);
            for (int r = 0; r < a.size; r++)
            {
                for (int c = 0; c < a.size; c++)
                {
                    temp[r, c] = temp[r, c] * b;
                }
            }
            return temp;
        }

        public Matrix4d Transpose()
        {
            Matrix4d temp = new Matrix4d(this);
            for (int r = 0; r < temp.size; r++)
            {
                for (int c = 0; c < temp.size; c++)
                {
                    this[r, c] = temp[c, r];

                }
            }
            return this;
        }

        public Matrix3d Sub(int x, int y)
        {
            Matrix3d sub = new Matrix3d();
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
        public float Det()
        {
            return
                mat[0, 3] * mat[1, 2] * mat[2, 1] * mat[3, 0] - mat[0, 2] * mat[1, 3] * mat[2, 1] * mat[3, 0] -
                mat[0, 3] * mat[1, 1] * mat[2, 2] * mat[3, 0] + mat[0, 1] * mat[1, 3] * mat[2, 2] * mat[3, 0] +
                mat[0, 2] * mat[1, 1] * mat[2, 3] * mat[3, 0] - mat[0, 1] * mat[1, 2] * mat[2, 3] * mat[3, 0] -
                mat[0, 3] * mat[1, 2] * mat[2, 0] * mat[3, 1] + mat[0, 2] * mat[1, 3] * mat[2, 0] * mat[3, 1] +
                mat[0, 3] * mat[1, 0] * mat[2, 2] * mat[3, 1] - mat[0, 0] * mat[1, 3] * mat[2, 2] * mat[3, 1] -
                mat[0, 2] * mat[1, 0] * mat[2, 3] * mat[3, 1] + mat[0, 0] * mat[1, 2] * mat[2, 3] * mat[3, 1] +
                mat[0, 3] * mat[1, 1] * mat[2, 0] * mat[3, 2] - mat[0, 1] * mat[1, 3] * mat[2, 0] * mat[3, 2] -
                mat[0, 3] * mat[1, 0] * mat[2, 1] * mat[3, 2] + mat[0, 0] * mat[1, 3] * mat[2, 1] * mat[3, 2] +
                mat[0, 1] * mat[1, 0] * mat[2, 3] * mat[3, 2] - mat[0, 0] * mat[1, 1] * mat[2, 3] * mat[3, 2] -
                mat[0, 2] * mat[1, 1] * mat[2, 0] * mat[3, 3] + mat[0, 1] * mat[1, 2] * mat[2, 0] * mat[3, 3] +
                mat[0, 2] * mat[1, 0] * mat[2, 1] * mat[3, 3] - mat[0, 0] * mat[1, 2] * mat[2, 1] * mat[3, 3] -
                mat[0, 1] * mat[1, 0] * mat[2, 2] * mat[3, 3] + mat[0, 0] * mat[1, 1] * mat[2, 2] * mat[3, 3];
        }
        
        public Matrix4d Adjugate()
        {
            Matrix4d adj = new Matrix4d();

            for (int r =0; r < size; r++)
            {
                for (int c =0; c < size; c++)
                {
                    adj[r, c] = this.Sub(r, c).Det();
                    if (((r + c) % 2) != 0)
                    {
                        adj[r, c] *= -1.0f;
                    }
                }
            }
            return adj;
        }
        public Matrix4d Inverse()
        {
            Matrix4d inverse = new Matrix4d();
            float det = Det();

            //Console.WriteLine(det);
            if (!Help.FloatEquality(det, 0.0f))
            {
                inverse = this.Adjugate().Transpose() * (1.0f / det);
            }
            return inverse;
        }
    }
}
