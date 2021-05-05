using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class Sphere
    {
        public Point position;
        public Material material;
        protected Matrix4d matrix = new Matrix4d();
        float radius;
        
        public Sphere(Scene scene, float radius = 1.0f) : base()
        {
             scene.AddRayObject(this);
            
            position = new Point(0.0f,0.0f,0.0f);
            material = new Material();
            this.radius = radius;
        }

        public Sphere(Scene scene, Point pos)
        {
            scene.AddRayObject(this);
            
            position = pos;
            material = new Material();
        }

        public void SetMatrix(Matrix4d matrix)
        {
            this.matrix = matrix;
        }

        public Matrix4d GetMatrix()
        {
            return this.matrix;
        }
        public List<float> Intersect(Ray ray)
        {
            List<float> intersectPoints = new List<float>();

            Ray transRay = GetMatrix() * ray;
            
            Point sphereToRay = transRay.origin - this.position;
            float a = transRay.direction.Dot(transRay.direction);
            float b = 2.0f * transRay.direction.Dot(sphereToRay);
            float c = sphereToRay.Dot(sphereToRay) - 1.0f;
            float discriminant = b * b - 4.0f * a * c;

            if (discriminant < 0)
            {
                return intersectPoints;
            }
            float t1 = (-b - (float)Math.Sqrt(discriminant)) / (2.0f * a);
            float t2 = (-b + (float)Math.Sqrt(discriminant)) / (2.0f * a);

            intersectPoints.Add(t1);
            intersectPoints.Add(t2);

            return intersectPoints;
        }

        public Vector GetNormal(Point point)
        {
            Point worldToLocal = GetMatrix().Inverse() * point;
            Vector normal = new Vector(worldToLocal - new Point(0, 0, 0));
            normal = GetMatrix().Inverse().Transpose() * normal;
            normal.w = 0;
            normal.Normalize();
            return normal;
        }
        public Color Lighting(Point position, Light light, Vector eye, Vector normal)
        {
            Color output = new Color();
            Color effectiveColor = material.color * light.intensity;
            Vector lightVec = new Vector(light.position - position).Normalize();
            Color ambientColor = effectiveColor * material.Ambient;
            Color diffuseColor;
            Color specularColor;

            float DotN = Vector.Dot(lightVec, normal);

            if (DotN < 0)
            {
                diffuseColor = Color.Black;
                specularColor = Color.Black;
            }
            else
            {
                diffuseColor = effectiveColor * material.Diffuse * DotN;
                Vector reflect = Vector.Reflect(-lightVec, normal);
                float rDotE = Vector.Dot(reflect, eye);

                if (rDotE <= 0)
                {
                    specularColor = Color.Black;
                }
                else
                {
                    float factor = (float)Math.Pow((double)rDotE, (double)material.Shinniness);
                    specularColor = light.intensity * material.Specular * factor;
                }
            }
            return ambientColor + diffuseColor + specularColor;
        }
    }
}
