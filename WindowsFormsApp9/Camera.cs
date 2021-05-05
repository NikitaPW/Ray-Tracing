using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public class Camera
    {
        public int hSize;
        public int vSize;
        public float fov;
        public Matrix4d transform;
        public float pixelSize;
        public float halfWidth;
        public float halfHeight;
        
        public Camera(int hSize = 500, int vSize = 300, float fov= Help.pi / 2.0f)
        {
            this.hSize = hSize;
            this.vSize = vSize;
            this.fov = fov;
            transform = new Matrix4d();
            CalculatePixelSize();
        }

        public void CalculatePixelSize()
        {
            float halfView = (float)Math.Tan(this.fov / 2.0);
            float aspect = this.hSize / (float)this.vSize;
            if (aspect >= 1)
            {
                this.halfWidth = halfView;
                this.halfHeight = halfView / aspect;
            }
            else
            {
                this.halfWidth = halfView * aspect;
                this.halfHeight = halfView;
            }
            this.pixelSize = (this.halfWidth * 2) / this.hSize ;
        }
        public Matrix4d SetCameraView(Point from, Point to, Vector up)
        {
            up = up.Normalize();
            Vector forward = new Vector(to - from).Normalize();
            Vector left = Vector.Cross(forward, up).Normalize();
            Vector true_up = Vector.Cross(left, forward).Normalize();
            Matrix4d orient = new Matrix4d(left.x, left.y, left.z, 0,
                                                true_up.x, true_up.y, true_up.z, 0,
                                                -forward.x, -forward.y, -forward.z, 0,
                                                0, 0, 0, 1);

            transform = orient * Matrix4d.TranslateMatrix(-from.x, -from.y, -from.z);
            return transform;
        }
    }
}
